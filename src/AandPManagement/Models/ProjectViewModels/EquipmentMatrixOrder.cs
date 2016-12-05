using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Models.ProjectViewModels
{
    public class EquipmentMatrixOrder
    {
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime COCDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime MajorDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime AnnualDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime LiftDate { get; set; }
        public string Location { get; set; }
        public bool Allocated { get; set; }
    }
}
