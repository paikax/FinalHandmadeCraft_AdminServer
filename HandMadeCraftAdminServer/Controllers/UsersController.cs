using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using HandMadeCraftAdminServer.Commons.StringEnums;
using HandMadeCraftAdminServer.Models.User;
using HandMadeCraftAdminServer.Services;
using HandMadeCraftAdminServer.VM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HandMadeCraftAdminServer.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userService.GetAll();
                return View(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when getting users: " + ex.Message);
                return View("Error");
            }
        }

        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.UpdateUser(user);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error when editing user: " + ex.Message);
                    return View("Error");
                }
            }
            return View(user);
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound();
            
            await _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }
        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Authenticate()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authenticate(AuthenticationRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userService.Authenticate(model.Email, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(model);
            }

            // Check if the user is an admin based on their role
            if (user.Role != StringEnums.Roles.AdminRole)
            {
                // If not an admin, deny access
                ModelState.AddModelError("", "You are not authorized to access this page");
                return View(model);
            }

            // Create claims for the authenticated user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                // Add more claims as needed...
            };

            var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties()
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(userIdentity), authProperties);

            return RedirectToAction("Index", "Users");
        }


        // Logout action
        public async Task<IActionResult> Logout()
        {
            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect to Home page or any other page after logout
            return RedirectToAction("Index", "Home");
        }
       
    }
}
