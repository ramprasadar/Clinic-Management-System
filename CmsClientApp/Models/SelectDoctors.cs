using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClientApp.Models
{
    public class SelectDoctors
    {
        [Display(Name = "Select Specialization")]
        public string SelectSpeciality { get; set; }
    }
}
