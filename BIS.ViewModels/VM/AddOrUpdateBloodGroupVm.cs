using System;
using System.ComponentModel.DataAnnotations;

namespace BIS.ViewModels.VM
{
   public class AddOrUpdateBloodGroupVm
    {
        public int? Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsDeleted { get; set; }  
    }
}
