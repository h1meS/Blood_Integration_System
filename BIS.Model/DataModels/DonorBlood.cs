using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BIS.Model.DataModels
{
    public class DonorBlood
    {
        public int DonorId { get; set; }
        public virtual Donor Donor { get; set; }
        public int BloodGroupId { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
    }
}