using System.ComponentModel.DataAnnotations;

namespace EJumping.IdentityServer.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}