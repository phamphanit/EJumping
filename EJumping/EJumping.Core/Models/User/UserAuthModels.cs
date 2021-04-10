using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EJumping.Core.Models.User
{
    public class UserValidationModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class LoginInputModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class LoggedOutViewModel
    {
        public string PostLogoutRedirectUri { get; set; }
        public string ClientName { get; set; }
        public string SignOutIframeUrl { get; set; }

        public bool AutomaticRedirectAfterSignOut { get; set; }

        public string LogoutId { get; set; }
        public bool TriggerExternalSignout => ExternalAuthenticationScheme != null;
        public string ExternalAuthenticationScheme { get; set; }
    }

    public class UserCreateModel
    {

        public UserCreateModel()
        {
        }

        [StringLength(maximumLength: 12, ErrorMessage = "validation.usercreate.model.usernamestringlengthexceeded|16", MinimumLength = 2)]
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "validation.usercreate.model.passwordstringlengthtooshort|6")]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        //public Gender Gender { get; set; }
        public UserLanguage PreferredLanguage { get; set; }
        //public GameTypes FavoriteGames { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Code { get; set; }
        public string Referrer { get; set; }
    }

    public class UserEditModel
    {
        public UserEditModel()
        {
        }

        public long Id { get; set; }
        //public string Introduction { get; set; }
        //public List<int> FavouriteGameTypes { get; set; }
        public bool IsReceivingPromotion { get; set; }
    }

    public class UserChangePasswordModel
    {
        public UserChangePasswordModel()
        {
        }

        [StringLength(maximumLength: 16)]
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class UserForgotPasswordModel
    {
        public UserForgotPasswordModel()
        {
        }

        public string Email { get; set; }
    }

    public class UserResetPasswordModel
    {
        public UserResetPasswordModel()
        {
        }
        //public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string PasswordConfirm { get; set; }
        public string Code { get; set; }
    }

    public class ChangeEmailModel
    {
        public ChangeEmailModel()
        {
        }
        public long UserId { get; set; }
        [EmailAddress(ErrorMessage = "register.emailformatisnotcorrect")]
        public string Email { get; set; }
    }


    public class ChallengeExternalLoginModel
    {
        public ChallengeExternalLoginModel()
        {
        }

        public string Provider { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        public RegisterExternalLoginModel()
        {
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class UserJsonModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
    }
}
