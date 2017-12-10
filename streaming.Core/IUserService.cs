using System;
using System.Collections.Generic;
using System.Text;

namespace streaming.Core
{
    public interface IUserService
    {
        bool Register(string email, string password);
    }
}
