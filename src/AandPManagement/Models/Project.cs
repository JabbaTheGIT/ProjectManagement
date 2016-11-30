using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Models
{
    public class Project
    {
        public int ProjectID { get; set; }

        [Required]
        [Display(Name = "Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string ProjectLocation { get; set; }

        [Display(Name = "Project Number")]
        public string ProjectNumber { get; set; }

        [Required]
        [Display(Name = "Client Name")]
        public string ProjectClient { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime ProjectStartDate { get; set; }

        [Display(Name = "Completed Date")]
        [DataType(DataType.Date)]
        public DateTime? ProjectCompletedDate { get; set; }

        [Display(Name = "Completed")]
        public bool ProjectCompleted { get; set; }

        public int? ClientCompanyID { get; set; }

        public ClientCompany ClientCompany { get; set; }
        public ICollection<ProjectTask> ProjectTasks { get; set; }
        public ICollection<Asset> Assets { get; set; }
        public ICollection<Personnel> Crew { get; set; }
    }
}
