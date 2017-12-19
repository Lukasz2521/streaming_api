using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace streaming.DAL.DTO
{
    public class RoleDTO : IdentityRole<int>
    {
        public string RoleName { get; set; } 
    }
}