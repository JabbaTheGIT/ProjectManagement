using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Models.ProjectViewModels
{
    public class ClientProjectIndex
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<ClientCompany> ClientCompanies { get; set; }
    }
}
