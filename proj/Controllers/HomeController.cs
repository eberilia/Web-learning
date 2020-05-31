using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proj.Models;

namespace proj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUser _user;

        public HomeController(ILogger<HomeController> logger, IUser user)
        {
            _logger = logger;
            _user = user;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _user.AddUser(user);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            User u = _user.GetUser(username);

            if(u != null)
            {
                if(password.Equals(u.Password))
                {
                    proj.Models.DataStorage.CurrentlyLoggedInUsername = username;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Error"] = "Nieprawidłowe hasło.";
                }
            }
            else
            {
                ViewData["Error"] = "Nieprawidłowa nazwa użytkownika.";
            }


            return View();

        
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
