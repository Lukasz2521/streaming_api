using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using streaming.DAL;
using streaming.DAL.Services;

namespace streaming.Controllers
{
    public class HomeController : Controller
    {
        private UserService _userService;

        public HomeController(Context context)
        {
            _userService = new UserService(context);      
        }

        public IActionResult Index()
        {
            //var list = _context.Album.Where(s => s.AlbumId < 5).ToList();

            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
