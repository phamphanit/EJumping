using System;
using System.Collections.Generic;
using System.Text;

namespace EJumping.Core.Models.User
{
    public class UserDetail
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string ProfileImageUrl { get; set; }
        public string PreferredLanguage { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string MfaSecret { get; set; }
        public bool? Locked { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public bool? EmailMarketing { get; set; }
        public bool? EmailServiceNotification { get; set; }
        public int Level { get; set; }
        public long Exp { get; set; }
        public long Point { get; set; }
        //public long LevelPoint { get; set; }
        public int? VerificationStatus { get; set; }
        public int? Status { get; set; }
        public DateTime? Created { get; set; }
        public bool IsSiteAdmin { get; set; }
    }


    public class UserRoleDetail
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public RoleDetail Role { get; set; }
    }

    public class RoleDetail
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class UserPublicDetailWithTenant {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public string PreferredLanguage { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Slogan { get; set; }
        public int? Status { get; set; }
        public DateTime? Created { get; set; }
    }

    public class UserPublicDetail
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public string PreferredLanguage { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Slogan { get; set; }
        public int? Status { get; set; }
        public DateTime? Created { get; set; }
    }

    public class UserCommentDetail
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
