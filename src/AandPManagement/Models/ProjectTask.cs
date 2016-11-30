using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Models
{
    public class ProjectTask
    {
        public int ProjectTaskID { get; set; }

        [Required]
        [Display(Name = "Task")]
        public string TaskTitle { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string TaskDescription { get; set; }

        [Display(Name = "Set Date")]
        [DataType(DataType.Date)]
        public DateTime TaskSetDate { get; set; }

        [Display(Name = "Target Date")]
        [DataType(DataType.Date)]
        public DateTime? TaskSetCompletionDate { get; set; }

        [Display(Name = "Actual Completion")]
        [DataType(DataType.Date)]
        public DateTime? TaskCompletedDate { get; set; }

        [Display(Name = "Task Completed")]
        public bool TaskComplete { get; set; }

        //For Foreign Key Access
        public int ProjectID { get; set; }
        public Project Project { get; set; }
    }
}
