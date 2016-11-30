using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Models
{
    public class ClientCompany
    {
        public int ClientCompanyID { get; set; }

        [Required]
        [Display(Name = "Organisation Name")]
        public string Name { get; set; }

        [Display(Name = "Organisation Address")]
        public string Address { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
