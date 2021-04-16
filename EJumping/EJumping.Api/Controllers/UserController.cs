using EJumping.BLL.User;
using EJumping.Core.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EJumping.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("~/api/user")]
        [ProducesResponseType(200)]

        public IActionResult GetUser()
        {
            var userId = User.GetId();
            if (userId == 0)
            {
                return this.StatusCode((int)HttpStatusCode.Unauthorized, "User has not logged in yet.");
            }

            // var result = _userService.GetUserById(userId, 0);
            var user = userService.GetFullUserById(userId);
            if (user == null)
            {
                return this.BadRequest(this.ModelState);
            }
            return this.Ok(user);
        }
    }
}
