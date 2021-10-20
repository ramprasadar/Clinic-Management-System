using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClientApp.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z0-9]*[^!@%~?:#$%^&*()']+$", ErrorMessage = "Special Characters are Not Allowed")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z0-9]*[^!@%~?:#$%^&*()']+$", ErrorMessage = "Special Characters are Not Allowed")]
        public string Lastname { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public string Specialization { get; set; }
       
        
        [Display(Name = "From")]

        [Required]
        public string StartTime { get; set; }
        
        
        [Display(Name = "To")]

        [Required]
        public string EndTime { get; set; }

        public Doctor() { }
        public Doctor(int DoctorId, string Firstname, string Lastname, string Sex, string Specialization, string StartTime, string EndTime)
        {
            this.DoctorId = DoctorId;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Sex = Sex;
            this.Specialization = Specialization;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }
    }
}
