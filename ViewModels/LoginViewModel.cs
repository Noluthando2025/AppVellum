
using System.ComponentModel.DataAnnotations;

namespace AppVellum.ViewModels
{
    // Defines the data required to authenticate an existing AppVellum user.
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
