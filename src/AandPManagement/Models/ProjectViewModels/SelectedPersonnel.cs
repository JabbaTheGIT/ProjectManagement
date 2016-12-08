using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Models.ProjectViewModels
{
    public class SelectedPersonnel
    {
        public ICollection<Training> SelectedPersonTraining { get; set; }
        public ICollection<Personnel> SelectedPerson { get; set; }
    }
}
