using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EJumping.Core.Models.User
{
    public class ApplicationUser : IdentityUser<long>
    {
        public int? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PreferredLanguage { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool? EmailMarketing { get; set; }
        public bool? EmailServiceNotification { get; set; }
        public int? Status { get; set; }    
        public int? VerificationStatus { get; set; }
        public DateTime? Created { get; set; }
    }

    public class ApplicationRole : IdentityRole<long>
    {
    }

    public class ApplicationUserRole : IdentityUserRole<long>
    {
    }
    public class ApplicationUserClaim : IdentityUserClaim<long>
    {
    }
    public class ApplicationRoleClaim : IdentityRoleClaim<long>
    {
    }
    public class ApplicationUserLogin : IdentityUserLogin<long>
    {
    }
    public class ApplicationUserToken : IdentityUserToken<long>
    {
    }

}
