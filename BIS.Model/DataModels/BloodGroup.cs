using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIS.Model.DataModels
{
    public class BloodGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type{ get; set; }  
        public virtual IList<DonorBlood> DonorBloods { get; set; }
    }
}