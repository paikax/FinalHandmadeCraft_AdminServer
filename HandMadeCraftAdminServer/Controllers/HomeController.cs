using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HandMadeCraftAdminServer.Models;
using Microsoft.AspNetCore.Authorization;

namespace HandMadeCraftAdminServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            string adminId = "100";
            string adminName = "Admin";
            string adminEmail = "admin@gmail.com";
            string adminPhotoUrl = "https://your-photo-url.jpg";

            ViewBag.AdminId = adminId;
            ViewBag.AdminName = adminName;
            ViewBag.AdminEmail = adminEmail;
            ViewBag.AdminPhotoUrl = adminPhotoUrl;
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