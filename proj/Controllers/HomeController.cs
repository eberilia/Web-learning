﻿using System;
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
        
        public IActionResult CreateUser(string? errorMessage) 
        {
            

            ViewBag.errorMessage = errorMessage;
            return View();
        }



        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            User u = _user.GetUser(user.Username);
            
            if (u == null)
                _user.AddUser(user);
            else
            {    
                return RedirectToAction("CreateUser", new { errorMessage = "Podana nazwa użytkownika już istnieje." });
            }


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

        public IActionResult Logout()
        {

            if(DataStorage.IsLoggedIn())
            {
                DataStorage.CurrentlyLoggedInUsername = "";
            }


            return RedirectToAction("Index");


        }

        public IActionResult MyProfile()
        {
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
