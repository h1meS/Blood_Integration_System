using System;
using System.ComponentModel.DataAnnotations;

namespace BIS.ViewModels.VM 
{
    public class AddOrUpdateDonorVm
    {
        public int? Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }  
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Diseases { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsDeleted { get; set; }   
    }
}
