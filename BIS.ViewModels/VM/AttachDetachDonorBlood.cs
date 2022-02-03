using System.ComponentModel.DataAnnotations;

namespace BIS.ViewModels.VM 
{
    public class AttachDetachDonorBloodVm
    {
        [Required]
        public int DonorId { get; set; }
        [Required]
        public int BloodGroupId { get; set; }
    }
}

