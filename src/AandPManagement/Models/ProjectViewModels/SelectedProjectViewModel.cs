using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Models.ProjectViewModels
{
    public class SelectedProjectViewModel
    {
        public ICollection<Personnel> SelectedProjectPersonnel { get; set; }
        public ICollection<ProjectTask> SelectedProjectTasks { get; set; }
        public ICollection<Asset> SelectedProjectAssets { get; set; }
        public ICollection<Project> SelectedProject { get; set; }
    }
}
