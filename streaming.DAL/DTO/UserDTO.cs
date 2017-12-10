using System;
using System.Collections.Generic;
using System.Text;

namespace streaming.DAL.DTO
{
    public class UserDTO
    {
        public int UserDTOId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string Password { get; set; }
    }
}
