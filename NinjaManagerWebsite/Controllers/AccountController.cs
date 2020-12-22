using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NinjaManagerWebsite.Models;

namespace NinjaManagerWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, 
                                SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        // GET - REGISTER
        public IActionResult Register()
        {
            return View();
        }

        //POST - REGISTER
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register obj)
        {
            if (ModelState.IsValid) 
            {
                var user = new ApplicationUser
                {
                    UserName = obj.Username
                };
                var result = await _userManager.CreateAsync(user, obj.Password);
                if (result.Succeeded) 
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(obj);
        }
       
        // GET - LOGIN
        public IActionResult Login()
        {
            return View();
        }

        //POST - LOGIN
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login obj)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(obj.Username, obj.Password, obj.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Login Invalid, enter valid e-mail password combination");

            }
            return View(obj);
        }
        
        //POST - LOGOUT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}