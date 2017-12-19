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
using streaming.DAL.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace streaming.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<UserDTO> _userManager;
        private readonly SignInManager<UserDTO> _signInManager;

        public AccountController(Context context, IConfiguration configuration, UserManager<UserDTO> userManager, SignInManager<UserDTO> signInManager)
        {
            _userService = new UserService(context);
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            
        }

        [HttpPost]
        public async Task<bool> LogIn([FromBody] LogInViewModel loginViewModel)
        {
            //_userService.Register(userLogin.Email, userLogin.Password);

            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email,
                                    loginViewModel.Password, false, lockoutOnFailure: false); //TODO - change remember me flag

                if (result.Succeeded)
                    return true;
            }

            return false;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<bool> Register([FromBody] LogInViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDTO { UserEmail = registerViewModel.Email };
                var result = await _userManager.CreateAsync(user, user.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    return true;
                }
            }

            return false;
        }

        #region Private methods

        private object GenerateJwtToken(string email, UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}