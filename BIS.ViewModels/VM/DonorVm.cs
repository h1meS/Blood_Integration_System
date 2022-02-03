using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BIS.ViewModels.VM
{
    public class DonorVm
    {
        public int Id { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Diseases { get; set; }  
        public IList<BloodGroupVm> BloodGroups { get; set; }
    }
}