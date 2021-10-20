using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsAPI.Model
{
    public class Cancel
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public DateTime VisitDate { get; set; }
        [Required]
        public String StartTime { get; set; }
        [Required]
        public String EndTime { get; set; }

    }
}
