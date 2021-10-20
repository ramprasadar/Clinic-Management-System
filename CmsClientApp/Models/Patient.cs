using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClientApp.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z0-9]*[^!@%~?:#$%^&*()']+$", ErrorMessage = "Special Characters are Not Allowed")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z0-9]*[^!@%~?:#$%^&*()']+$", ErrorMessage = "Special Characters are Not Allowed")]
        public string Lastname { get; set; }
        [Required]
        public string Sex { get; set; }

        [Required]
        [Range(1, 120, ErrorMessage = "Age should be <=120 years")]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }
}
