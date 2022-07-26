using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsAPI.Model
{
    public class UserSetup
    {
        [Key]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Special Characters not allowed")]
        public string Username { get; set; }

        [Required(ErrorMessage = "FirstName is Required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "LastName is Required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "EmailId is Required")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "At least one uppercase, one lowercase, one digit, one special character and minimum eight in length")]
        [DataType(DataType.Password)]
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
        public DateTime? CreationDate { get; set; }
    }
}
