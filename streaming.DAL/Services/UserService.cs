using System;
using System.Collections.Generic;
using System.Text;
using streaming.Config;
using streaming.DAL.DTO;
using streaming.Core;

namespace streaming.DAL.Services
{
    public class UserService: IUserService
    {
        private Context _context;

        public UserService(Context context)
        {
            _context = context;
        }

        public bool Register(string email, string password)
        {
            string hashedPassword = SecurityManager.Encrypt(password, true);
            _context.Users.AddAsync(new UserDTO() { UserEmail = email, Password = password });

            return true;
        }

        public bool LogIn()
        {

            return true;
        }
    }
}
