using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EJumping.Core.Models.Configurations;
using EJumping.Core.Models.Filters;
using EJumping.Core.Models.User;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;

namespace EJumping.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly EJumpingWebConfiguration ejumpingConfiguration;
        public AuthController(UserManager<ApplicationUser> userManager, IOptions<EJumpingWebConfiguration> ejumpingConfiguration)
        {
            this.userManager = userManager;
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
        [Route("register")]
        [ProducesResponseType(201)]
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
                        BirthDate = DateTime.UtcNow,
                        PreferredLanguage = "ko",
                        VerificationStatus = (int)UserVerificationStatus.Verified,
                        EmailConfirmed = true,
                        Status = (int)UserStatus.Active,
                        ProfileImageUrl = "https://mo2ja.s3.ap-northeast-2.amazonaws.com/images/level/level_0.png",
                        Created = DateTime.UtcNow
                    };

                    var result = await this.userManager.CreateAsync(account, model.Password);
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

                                UserName = model.UserName,
                                Password = model.Password
                            });

                            if (response.IsError)
                            {
                                this.ModelState.AddModelError("Register", response.Error);
                                return BadRequest(this.ModelState);
                            }

                            return this.Created(
                                "~/",
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
                        foreach (var error in result.Errors)
                        {
                            if (error.Code == "DuplicateEmail")
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
    }
}
