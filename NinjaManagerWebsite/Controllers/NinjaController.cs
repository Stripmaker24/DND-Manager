using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using NinjaManagerWebsite.Data;
using NinjaManagerWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace NinjaManagerWebsite.Controllers
{
    [Authorize(Roles = "User, Admin, Owner")]
    public class NinjaController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public NinjaController(AppDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            IEnumerable<Ninja> objList = _db.Ninjas.Where(n => n.ownerId == _userManager.GetUserId(HttpContext.User));
            return View(objList);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ninja obj)
        {
            if (ModelState.IsValid)
            {
                obj.ownerId = _userManager.GetUserId(HttpContext.User);
                _db.Ninjas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Ninjas.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            if (obj.ownerId != _userManager.GetUserId(HttpContext.User)) 
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ninja obj)
        {
            if (ModelState.IsValid)
            {
                obj.ownerId = _userManager.GetUserId(HttpContext.User);
                _db.Ninjas.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Ninjas.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            if (obj.ownerId != _userManager.GetUserId(HttpContext.User))
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePerm(int? id)
        {
            List<Ninja> ninjas = _db.Ninjas.Include("itemOfNinjas").ToList();
            Ninja obj = ninjas.Where(n => n.Id == id).First();
            if (obj == null)
            {
                return NotFound();
            }
            if (obj.itemOfNinjas.Count() != 0) 
            {
                _db.ItemOfNinjas.RemoveRange(_db.ItemOfNinjas.Where(i => i.NinjaId == id));
            }
            _db.Ninjas.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET - INVENTORY
        public IActionResult Inventory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ItemWithCategory _headItem = new ItemWithCategory();
            ItemWithCategory _chestItem = new ItemWithCategory();
            ItemWithCategory _handItem = new ItemWithCategory();
            ItemWithCategory _feetItem = new ItemWithCategory();
            ItemWithCategory _ringItem = new ItemWithCategory();
            ItemWithCategory _necklaceItem = new ItemWithCategory();
            List <Ninja> ninjas = _db.Ninjas.Include("itemOfNinjas").ToList();
            Ninja myNinja = ninjas.Where(n => n.Id == id).First();
            if (myNinja == null)
            {
                return NotFound();
            }
            if (myNinja.ownerId != _userManager.GetUserId(HttpContext.User))
            {
                return NotFound();
            }
            int supInt = 0;
            int supStr = 0;
            int supDex = 0;
            int value = 0;
            foreach (var item in myNinja.itemOfNinjas)
            {
                var tempItem = _db.Items.Find(item.ItemId);
                switch (tempItem.CategoryId)
                {
                    case 1:
                        _headItem.item = tempItem;
                        _headItem.category = _db.Categories.Find(tempItem.CategoryId);
                        break;
                    case 2:
                        _chestItem.item = tempItem;
                        _chestItem.category = _db.Categories.Find(tempItem.CategoryId);
                        break;
                    case 3:
                        _handItem.item = tempItem;
                        _handItem.category = _db.Categories.Find(tempItem.CategoryId);
                        break;
                    case 4:
                        _feetItem.item = tempItem;
                        _feetItem.category = _db.Categories.Find(tempItem.CategoryId);
                        break;
                    case 5:
                        _ringItem.item = tempItem;
                        _ringItem.category = _db.Categories.Find(tempItem.CategoryId);
                        break;
                    case 6:
                        _necklaceItem.item = tempItem;
                        _necklaceItem.category = _db.Categories.Find(tempItem.CategoryId);
                        break;
                    default:
                        break;
                }
                supInt = supInt + tempItem.Intelligence;
                supStr = supStr + tempItem.Strenght;
                supDex = supDex + tempItem.Dexterity;
                value = value + tempItem.Value;
            }
            NinjaInventory inv = new NinjaInventory();
            inv.Ninja = myNinja;
            inv.headItem = _headItem;
            inv.chestItem = _chestItem;
            inv.handItem = _handItem;
            inv.feetItem = _feetItem;
            inv.ringItem = _ringItem;
            inv.necklaceItem = _necklaceItem;
            inv.totalInt = supInt;
            inv.totalStr = supStr;
            inv.totalDex = supDex;
            inv.totalItemValue = value;
            return View(inv);
        }
    }
}