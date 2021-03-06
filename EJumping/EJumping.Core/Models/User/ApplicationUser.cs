using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EJumping.Core.Models.User
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        //public string UserName { get; set; }

        //public string NormalizedUserName { get; set; }

        //public string Email { get; set; }

        //public string NormalizedEmail { get; set; }

        //public bool EmailConfirmed { get; set; }

        //public string PasswordHash { get; set; }

        //public string PhoneNumber { get; set; }

        //public bool PhoneNumberConfirmed { get; set; }

        //public bool TwoFactorEnabled { get; set; }

        //public string ConcurrencyStamp { get; set; }

        //public string SecurityStamp { get; set; }

        //public bool LockoutEnabled { get; set; }

        //public DateTimeOffset? LockoutEnd { get; set; }

        //public int AccessFailedCount { get; set; }

    }

    public class ApplicationRole : IdentityRole<Guid>
    {
    }

    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
    }
    public class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
    }
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
    }
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
    }
    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
    }

}
