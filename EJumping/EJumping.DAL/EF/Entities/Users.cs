using System;
using System.Collections.Generic;

namespace EJumping.DAL.EF.Entities
{
    public partial class Users
    {
        public Users()
        {
            NewsComment = new HashSet<NewsComment>();
            UserBlockBlockedUser = new HashSet<UserBlock>();
            UserBlockUser = new HashSet<UserBlock>();
            UserClaim = new HashSet<UserClaim>();
            UserExpLog = new HashSet<UserExpLog>();
            UserFriendFriend = new HashSet<UserFriend>();
            UserFriendUser = new HashSet<UserFriend>();
            UserLogin = new HashSet<UserLogin>();
            UserLoginLog = new HashSet<UserLoginLog>();
            UserMessageReceiver = new HashSet<UserMessage>();
            UserMessageSender = new HashSet<UserMessage>();
            UserPointLog = new HashSet<UserPointLog>();
            UserRole = new HashSet<UserRole>();
        }

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
        public int? VerificationStatus { get; set; }
        public int? Status { get; set; }
        public DateTime? Created { get; set; }
        public long Exp { get; set; }
        public long Point { get; set; }
        public DateTime? LastMessagesRead { get; set; }
        public DateTime? LastFriendrequestsRead { get; set; }

        public virtual UserToken UserToken { get; set; }
        public virtual ICollection<NewsComment> NewsComment { get; set; }
        public virtual ICollection<UserBlock> UserBlockBlockedUser { get; set; }
        public virtual ICollection<UserBlock> UserBlockUser { get; set; }
        public virtual ICollection<UserClaim> UserClaim { get; set; }
        public virtual ICollection<UserExpLog> UserExpLog { get; set; }
        public virtual ICollection<UserFriend> UserFriendFriend { get; set; }
        public virtual ICollection<UserFriend> UserFriendUser { get; set; }
        public virtual ICollection<UserLogin> UserLogin { get; set; }
        public virtual ICollection<UserLoginLog> UserLoginLog { get; set; }
        public virtual ICollection<UserMessage> UserMessageReceiver { get; set; }
        public virtual ICollection<UserMessage> UserMessageSender { get; set; }
        public virtual ICollection<UserPointLog> UserPointLog { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
