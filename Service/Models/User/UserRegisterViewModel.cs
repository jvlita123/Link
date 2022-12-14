using System.ComponentModel.DataAnnotations;

namespace Service.Services.ViewModels.User
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Please confirm your password.")]
        public string ConfirmPassword { get; set; }
    }
}