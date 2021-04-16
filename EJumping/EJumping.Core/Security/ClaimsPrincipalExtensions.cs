using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EJumping.Core.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetId(this ClaimsPrincipal principle)
        {
            var claim = principle.Claims.Any() ? principle.Claims.FirstOrDefault(x => x.Type == "sub") : null;
            // for admin site
            if (claim == null)
            {
                claim = principle.Claims.Any() ? principle.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")) : null;
            }

            int.TryParse(claim?.Value, out var userId);
            return userId;
        }
    }
}
