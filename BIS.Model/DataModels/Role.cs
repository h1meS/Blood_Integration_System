using Microsoft.AspNetCore.Identity;
using System;

namespace BIS.Model.DataModels
{
    public class Role : IdentityRole<int>
    {
        public RoleValue RoleValue { get; set; }
        public Role()
        {}
        public Role (string name,RoleValue roleValue )
        {}
    }
}