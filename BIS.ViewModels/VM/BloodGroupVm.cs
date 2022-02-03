using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BIS.ViewModels.VM
{
    public class BloodGroupVm
    {
        public int Id { get; set; }   
        [Required]
        public string Type{ get; set; } 
        [Required] 
        public IList<DonorVm> Donors { get; set; }  
    }
}