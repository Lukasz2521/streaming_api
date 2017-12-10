using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using streaming.ViewModels;
using streaming.DAL;
using streaming.DAL.Services;
using streaming.Core;

namespace streaming.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(Context context)
        {
            _userService = new UserService(context);
        }

        [HttpPost]
        public IActionResult LogIn([FromBody] LogInViewModel userLogin)
        {
            _userService.Register(userLogin.Email, userLogin.Password);

            return Json( new {  } );
        }


    }
}