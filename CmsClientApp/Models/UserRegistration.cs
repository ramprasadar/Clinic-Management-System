using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClientApp.Models
{
    public class UserRegistration
    {
        [Key]
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z]{4,15}+$", ErrorMessage = "Special Characters & Numbers are not allowed and Range should be {4,15}")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        [RegularExpression(@"^[a-zA-Z]{4,15}+$", ErrorMessage = "Special Characters not allowed and Range should be {4,15}")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        [RegularExpression(@"^[a-zA-Z]{4,15}+$", ErrorMessage = "Special Characters not allowed and Range should be {4,15}")]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("[a-z0-9]+@gmail.com", ErrorMessage = "Invalid mail id")]
        public string EmailId { get; set; }

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
        public bool Status { get; set; }
        public string SecurityCode { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
