﻿using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PL.Controllers
{
    [Authorize(Roles = "Admin")]

    public class UsersController1 : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UsersController1> _logger;

        public UsersController1(UserManager<ApplicationUser> userManager,ILogger<UsersController1> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> Index(string SearchValue="")
        {
            List<ApplicationUser> users;
            if(string.IsNullOrEmpty(SearchValue))
            {
                users = await _userManager.Users.ToListAsync();
            }
            else
            {
                users = await _userManager.Users.Where(user=>user.Email.Trim().ToLower().Contains(SearchValue.Trim().ToLower())).ToListAsync();
            }
            return View(users);
        }

        public async Task<IActionResult>Details(string id, string viewName="Details")
        {
            if (id == null)
                return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            return View(viewName, user);
        }
        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id,ApplicationUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id);
                    user.UserName = appUser.UserName;
                    user.NormalizedUserName = appUser.UserName.ToUpper();

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch (Exception ex)
                {

                    _logger.LogError(ex.Message);
                }
            }
            return View(appUser);
        }
        public async Task<IActionResult> Delete(string id, ApplicationUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
