﻿using System;
using System.Threading.Tasks;
using HandMadeCraftAdminServer.Models.User;
using HandMadeCraftAdminServer.Services;
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
        
        // GET: Users
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

        // GET: Users/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserById(id.Value);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
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


        // GET: Users/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserById(id.Value);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when deleting user: " + ex.Message);
                return View("Error");
            }
        }
    }
}