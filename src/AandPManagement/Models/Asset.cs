using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AandPManagement.Models
{
    public class Asset
    {
        public int AssetID { get; set; }

        [Required]
        [Display(Name = "Serial Number")]
        public string AssetSerialNumber { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string AssetDescription { get; set; }

        [Display(Name = "MPI Test Date")]
        [DataType(DataType.Date)]
        public DateTime? AssetMPITestDate { get; set; }

        [Display(Name = "Visual Test Date")]
        [DataType(DataType.Date)]
        public DateTime? AssetVisualTestDate { get; set; }

        [Display(Name = "Anual Test Date")]
        [DataType(DataType.Date)]
        public DateTime? AssetAnualTestDate { get; set; }

        [Display(Name = "Major Test Date")]
        [DataType(DataType.Date)]
        public DateTime? AssetMajorTestDate { get; set; }

        [Display(Name = "COC Date")]
        [DataType(DataType.Date)]
        public DateTime? AssetCOCDate { get; set; }

        [Display(Name = "Load Test Date")]
        [DataType(DataType.Date)]
        public DateTime? AssetLiftDate { get; set; }

        public string COC { get; set; }

        [Display(Name = "Dimensions (H x W x D) M")]
        public string AssetDimensions { get; set; }

        [Display(Name = "Weight Kg")]
        public int? AssetWeight { get; set; }

        [Display(Name = "Connection")]
        public string AssetConnections { get; set; }

        [Display(Name = "Pressure psi")]
        public int? AssetPressureRating { get; set; }

        [Display(Name = "Location")]
        public string AssetLocation { get; set; }

        [Display(Name = "Allocated to Project")]
        public bool AssetAllocated { get; set; }

        [Display(Name = "Project Pre-Job Check")]
        public bool AssetPreJobCheck { get; set; }

        //For Foreign Key Access
        public int? ProjectID { get; set; }
        public Project Project { get; set; }
    }
}
