using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Models
{
    public class Training
    {
        public int TrainingID { get; set; }

        public string TypeTraining { get; set; }

        public DateTime DateOfTraining { get; set; }


        //For Foreign Key Access
        public int PersonnelID { get; set; }

        public Personnel Personnel { get; set; }
    }
}
