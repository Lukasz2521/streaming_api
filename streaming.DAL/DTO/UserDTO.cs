using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace streaming.DAL.DTO
{
    public class UserDTO : IdentityUser<int>
    {

        public string UserEmail { get; set; }

        public string Password { get; set; }
    }
}
