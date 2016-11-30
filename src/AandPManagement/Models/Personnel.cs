using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Models
{
    public class Personnel
    {
        public int PersonnelID { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Position")]
        public int Position { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        //For Foreign Key Access
        public int? ProjectID { get; set; }
        public Project Project { get; set; }
    }
}
