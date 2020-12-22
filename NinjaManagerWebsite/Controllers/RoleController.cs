using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NinjaManagerWebsite.Models;

namespace NinjaManagerWebsite.Controllers
{
    [Authorize(Roles = "Owner")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index() 
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        
        //GET - DETAIL
        public async Task<IActionResult> Detail(string id) 
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null) 
            {
                return NotFound();
            }

            var obj = new ERole
            {
                Id = role.Id,
                RoleName = role.Name
            };
            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name)) 
                {
                    obj.Users.Add(user.UserName);
                }
            }
            return View(obj);
        }
        //GET - EDITUSERSINROLE
        public async Task<IActionResult> EditUsersInRole(string Id) 
        {
            var role = await _roleManager.FindByIdAsync(Id);

            if (role == null)
            {
                return NotFound();
            }

            var modelList = new List<User>();
            foreach (var user in _userManager.Users)
            {
                var _user = new User
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await _userManager.IsInRoleAsync(user, role.Name)) 
                {
                    _user.IsSelected = true;
                }
                else
                {
                    _user.IsSelected = false;
                }
                modelList.Add(_user);
            }
            var model = new UserRole { RoleId = role.Id, Users = modelList };
            return View(model);
        }
        // POST - EDITUSERSINROLE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUsersInRole(UserRole userRole)
        {
            var role = await _roleManager.FindByIdAsync(userRole.RoleId);

            if (role == null)
            {
                return NotFound();
            }

            foreach (var user in userRole.Users)
            {
                var _user = await _userManager.FindByIdAsync(user.UserId);
                if (user.IsSelected && !(await _userManager.IsInRoleAsync(_user, role.Name)))
                {
                    await _userManager.AddToRoleAsync(_user, role.Name);
                }
                else if (!user.IsSelected && await _userManager.IsInRoleAsync(_user, role.Name))
                {
                    await _userManager.RemoveFromRoleAsync(_user, role.Name);
                }
                else 
                {
                    continue;
                }
            }
            return RedirectToAction("Detail", new { Id = userRole.RoleId });
        }
    }
}