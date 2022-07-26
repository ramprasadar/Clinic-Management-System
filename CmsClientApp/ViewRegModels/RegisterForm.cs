using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClientApp.ViewRegModels
{
    public class RegisterForm
    {
        [Key]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Special Characters not allowed")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("[a-z0-9]+@gmail.com", ErrorMessage = "Please provide gmail account only")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "At least one uppercase, one lowercase, one digit, one special character and minimum eight in length")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string SecurityQuestion { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required(ErrorMessage = "Please enter captcha")]
        public string Captcha { get; set; }
        [Required(ErrorMessage = "Please enter captcha")]
        public string resultCaptcha { get; set; }

    }
}
