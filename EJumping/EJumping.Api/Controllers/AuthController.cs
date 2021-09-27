using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using EJumping.Core.Models.Configurations;
using EJumping.Core.Models.Filters;
using EJumping.Core.Models.User;
using Google.Apis.Auth;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;

namespace EJumping.Api.Controllers
{
    [Route("/api/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly EJumpingWebConfiguration ejumpingConfiguration;
        public AuthController(UserManager<ApplicationUser> userManager, IOptions<EJumpingWebConfiguration> ejumpingConfiguration, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ejumpingConfiguration = ejumpingConfiguration.Value;
        }
        /// <summary>
        /// Create a user.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [AllowAnonymous]
        [HttpPost]
        //[Route("register")]
        [Route("/api/auth/register")]

        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(ValidationResultModel))]
        public async Task<IActionResult> Register([FromBody] UserCreateModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var account = new ApplicationUser
                    {
                        Email = model.Email,
                        UserName = model.UserName,
                        EmailConfirmed = true,
                    };

                    var result = await this.userManager.CreateAsync(account,model.Password);
                    if (result.Succeeded)
                    {

                        using (var client = new HttpClient())
                        {
                            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                            {
                                Address = ejumpingConfiguration.IdSrvUrl + "/connect/token",

                                ClientId = "EJumping.WebApi",
                                ClientSecret = "secret",
                                Scope = "openid profile EJumping.WebAPI",

                                UserName = model.UserName,
                                Password = model.Password
                            });

                            if (response.IsError)
                            {
                                this.ModelState.AddModelError("Register", response.Error);
                                return BadRequest(this.ModelState);
                            }
                            return this.Ok(new
                            {
                                access_token = response.AccessToken,
                                expires_in = response.ExpiresIn,
                                token_type = response.TokenType
                            });
                        }
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            if (error.Code == "DuplicateEmaill")
                            {
                                this.ModelState.AddModelError(string.Empty, "register.duplicateemail|" + model.Email);
                            }
                            else if (error.Code == "PasswordRequiresUpper")
                            {
                                this.ModelState.AddModelError(string.Empty, "register.requiresupper");
                            }
                            else if (error.Code == "PasswordRequiresUniqueChars")
                            {
                                this.ModelState.AddModelError(string.Empty, "register.requiresuniquechars");
                            }
                            else
                            {
                                this.ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }

                        return this.BadRequest(this.ModelState);
                    }
                }
                catch (Exception e)
                {
                    Log.Information(e, "error on register");
                    this.ModelState.AddModelError(string.Empty, "server-generalerror");
                }

            }

            return this.BadRequest(this.ModelState);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(ValidationResultModel))]
        public async Task<IActionResult> Login([FromBody] LoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await this.userManager.FindByNameAsync(model.Username);
                if (user == null)
                {
                    //try to find with email - model.Username is the email 
                    user = await this.userManager.FindByEmailAsync(model.Username);
                    if (user == null)
                    {
                        this.ModelState.AddModelError("Login", "validation.login.invalidusername");
                        return this.BadRequest(this.ModelState);
                    }
                }

                var result = await this.signInManager.PasswordSignInAsync(user, model.Password, true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    //if (user.Status != (int)UserStatus.Active)
                    //{
                    //    this.ModelState.AddModelError("Login", "validation.login.accountdeactivated");
                    //    return this.BadRequest(this.ModelState);
                    //}


                    using (var client = new HttpClient())
                    {
                        var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                        {
                            Address = ejumpingConfiguration.IdSrvUrl + "/connect/token",

                            ClientId = "ro.client",
                            ClientSecret = "secret",
                            Scope = "api1 openid profile",

                            UserName = user.UserName,
                            Password = model.Password
                        });

                        if (response.IsError)
                        {
                            this.ModelState.AddModelError("Login", response.Error);
                            return BadRequest(this.ModelState);
                        }


                        return this.Ok(
                            new
                            {
                                access_token = response.AccessToken,
                                expires_in = response.ExpiresIn,
                                token_type = response.TokenType
                            });

                    }
                }
                else
                {
                    var attemptingAccount = this.userManager.FindByNameAsync(model.Username).Result;
                    var accessFailedCount = 0;
                    if (attemptingAccount != null)
                    {
                        accessFailedCount = attemptingAccount.AccessFailedCount;
                    }
                    if (accessFailedCount >= 10)
                    {
                        ModelState.AddModelError("Login", "validation.login.lockuserfor30minutes");
                    }
                    else if (accessFailedCount >= 3)
                    {
                        ModelState.AddModelError("Login", "validation.login.remindforgotpassword");
                    }
                    else if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("Login", "validation.login.islockedout");
                    }
                    else if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError("Login", "validation.login.isnotallowed");
                    }
                    else
                    {
                        ModelState.AddModelError("Login", "validation.login.invalidloginattempt");
                    }
                    return this.BadRequest(this.ModelState);
                }
            }

            return this.BadRequest(this.ModelState);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("google")]
        public async Task<ActionResult> GoogleLogin([FromBody] GoogleLoginModel model)
        {
            var info = GoogleJsonWebSignature.ValidateAsync(model.UserToken, new GoogleJsonWebSignature.ValidationSettings()).Result;

            if (info == null)
            {
                //return this.RedirectPermanent("/");
                throw new Exception("signInManager.GetExternalLoginInfoAsync fails");
            }
            var email = info.Email;
            var user = new ApplicationUser();
            if (email != null)
            {
                user = await this.userManager.FindByEmailAsync(email);
            }
            // Sign in the user with this external login provider if the user already has a login.
            if (user != null)
            {

                using (var client = new HttpClient())
                {
                    var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                    {
                        Address = ejumpingConfiguration.IdSrvUrl + "/connect/token",

                        ClientId = "ro.client",
                        ClientSecret = "secret",
                        Scope = "api1 openid profile",

                        UserName = user.UserName,
                        Password = "1qaz!QAZ",
                    });

                    if (response.IsError)
                    {
                        return BadRequest();
                    }
                    return this.Ok(new
                    {
                        access_token = response.AccessToken,
                        expires_in = response.ExpiresIn,
                        token_type = response.TokenType
                    });
                }

            }
            else
            {
                if (email != null)
                {
                    user = new ApplicationUser
                    {
                        UserName = info.Name,
                        Email = info.Email,
                        //ProfileImageUrl = info.Picture
                    };

                    await userManager.CreateAsync(user, "1qaz!QAZ");

                    using (var client = new HttpClient())
                    {
                        var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                        {
                            Address = ejumpingConfiguration.IdSrvUrl + "/connect/token",

                            ClientId = "ro.client",
                            ClientSecret = "secret",
                            Scope = "api1 openid profile",

                            UserName = user.UserName,
                            Password = "1qaz!QAZ",
                        });

                        if (response.IsError)
                        {
                            this.ModelState.AddModelError("Register", response.Error);
                            return BadRequest(this.ModelState);
                        }
                        return this.Ok(new
                        {
                            access_token = response.AccessToken,
                            expires_in = response.ExpiresIn,
                            token_type = response.TokenType
                        });
                    }
                }
                return BadRequest();

            }
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("challengeExternalLogin")]
        public async Task<ActionResult> ChallengeExternalLogin(string provider, string returnUrl)
        {
            //HttpContext.Response.Cookies.Append("isauthenticating", "true");
            var redirectUrl = "/api/auth/externalLoginCallBack?returnUrl=" + returnUrl;
            var properties = this.signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return this.Challenge(properties, provider);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("externalLoginCallBack")]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                //return this.RedirectPermanent("/");
                throw new Exception(remoteError);
            }
            var info = await this.signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                //return this.RedirectPermanent("/");
                throw new Exception("signInManager.GetExternalLoginInfoAsync fails");
            }
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var user = new ApplicationUser();
            if (email != null)
            {
                user = await this.userManager.FindByEmailAsync(email);
            }
            // Sign in the user with this external login provider if the user already has a login.
            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {

                using (var client = new HttpClient())
                {
                    var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                    {
                        Address = ejumpingConfiguration.IdSrvUrl + "/connect/token",

                        ClientId = "ro.client",
                        ClientSecret = "secret",
                        Scope = "api1 openid profile",

                        UserName = user.UserName,
                        Password = "1qaz!QAZ",
                    });

                    if (response.IsError)
                    {
                        return BadRequest();
                    }
                    return this.Ok(new
                    {
                        access_token = response.AccessToken,
                        expires_in = response.ExpiresIn,
                        token_type = response.TokenType
                    });
                }

            }
            else
            {
                if (email != null)
                {
                    user = new ApplicationUser
                    {
                        UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                    };

                    await userManager.CreateAsync(user, "1qaz!QAZ");


                    await userManager.AddLoginAsync(user, info);
                    await signInManager.SignInAsync(user, isPersistent: false);

                    using (var client = new HttpClient())
                    {
                        var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                        {
                            Address = ejumpingConfiguration.IdSrvUrl + "/connect/token",

                            ClientId = "ro.client",
                            ClientSecret = "secret",
                            Scope = "api1 openid profile",

                            UserName = user.UserName,
                            Password = "1qaz!QAZ",
                        });

                        if (response.IsError)
                        {
                            this.ModelState.AddModelError("Register", response.Error);
                            return BadRequest(this.ModelState);
                        }
                        return this.Ok(new
                        {
                            access_token = response.AccessToken,
                            expires_in = response.ExpiresIn,
                            token_type = response.TokenType
                        });
                    }
                }
                return BadRequest();

            }
        }

    }
    public class GoogleLoginModel
        {
        public string UserToken { get; set; }
 }

}
