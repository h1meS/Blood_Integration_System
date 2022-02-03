using Microsoft.AspNetCore.Identity;
using System;

namespace BIS.Model.DataModels
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}