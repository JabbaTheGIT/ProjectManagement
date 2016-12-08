using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Models
{
    public class Training
    {
        public int TrainingID { get; set; }

        [Required]
        [Display(Name = "Training Title")]
        public string TypeTraining { get; set; }

        [Required]
        [Display(Name = "Date training completed")]
        [DataType(DataType.Date)]
        public DateTime DateOfTraining { get; set; }


        //For Foreign Key Access
        public int PersonnelID { get; set; }
        public Personnel Personnel { get; set; }
    }
}
