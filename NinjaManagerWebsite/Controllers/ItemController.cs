using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinjaManagerWebsite.Data;
using NinjaManagerWebsite.Models;

namespace NinjaManagerWebsite.Controllers
{
    [Authorize(Roles ="Admin, Owner")]
    public class ItemController : Controller
    {
        private readonly AppDbContext _db;
        public ItemController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var Items = _db.Items.ToList();
            List<ItemWithCategory> ItemsWithCategory = new List<ItemWithCategory>();
            foreach (var item in Items)
            {
                ItemsWithCategory.Add(new ItemWithCategory
                {
                    item = _db.Items.Find(item.Id),
                    category = _db.Categories.Find(_db.Items.Find(item.Id).CategoryId)
                });
            }
            List<ItemWithCategory> SortedItemsWithCategory = ItemsWithCategory.OrderBy(i => i.category.Id).ToList();
            return View(SortedItemsWithCategory);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            var item = new Item();
            var categories = _db.Categories.ToList();
            return View(new CEDItem { item = item, categories = categories });
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CEDItem newItem) 
        {
            if (ModelState.IsValid)
            {
                SaveItem(newItem);
                return RedirectToAction("Index");
            }
            return View(newItem);
        }

        //GET - EDIT
        public IActionResult Edit(int? id) 
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            var categories = _db.Categories.ToList();
            return View(new CEDItem { item = item, categories = categories });
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CEDItem newItem) 
        {
            if (ModelState.IsValid)
            {
                SaveItem(newItem);
                return RedirectToAction("Index");
            }
            return View(newItem);
        }

        //GET - DELETE
        public IActionResult Delete(int? id, string? err) 
        {
            if (err != null) 
            {
                ModelState.AddModelError(string.Empty, err);
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            var categories = _db.Categories.ToList();
            return View(new CEDItem { item = obj, categories= categories });
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePerm(CEDItem banItem) 
        {
            var obj = _db.Items.Find(banItem.item.Id);
            if (obj == null)
            {
                return NotFound();
            }
            List<Item> items = _db.Items.Where(i => i.CategoryId == obj.CategoryId).ToList();
            if (items.Count() <= 3) 
            {
                return RedirectToAction("Delete", new { id = banItem.item.Id, err = "Can not ban this item: amount of items of this type would be to low" });
            }
            SellItemAll(obj.Id);
            _db.Items.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void SaveItem(CEDItem newItem) 
        {
            Item thisItem;
            if (newItem.item.Id == 0) 
            {
                thisItem = new Item();
                _db.Items.Add(thisItem);
            }
            else
            {
                thisItem = _db.Items.Find(newItem.item.Id);
            }
            thisItem.Name = newItem.item.Name;
            thisItem.Value = newItem.item.Value;
            thisItem.Strenght = newItem.item.Strenght;
            thisItem.Dexterity = newItem.item.Dexterity;
            thisItem.Intelligence = newItem.item.Intelligence;
            if (thisItem.CategoryId != newItem.item.CategoryId) 
            {
                if (thisItem.CategoryId == 0) 
                {
                    thisItem.CategoryId = newItem.item.CategoryId;
                }
                else
                {
                    ChangeOfType(newItem.item);
                    thisItem.CategoryId = newItem.item.CategoryId;
                }
            }
            _db.SaveChanges();
        }

        private void ChangeOfType(Item item) 
        {
            List<ItemOfNinja> ninjasWithThisItem = _db.ItemOfNinjas.Where(i => i.ItemId == item.Id).ToList();
            List<Ninja> ninjas = new List<Ninja>();
            foreach (var ninja in ninjasWithThisItem)
            {
                ninjas.Add(_db.Ninjas.Find(ninja.NinjaId));
            }
            foreach (var ninja in ninjas)
            {
                List<ItemOfNinja> ItemsOfNinja = _db.ItemOfNinjas.Where(n => n.NinjaId == ninja.Id).ToList();
                foreach (var ninjaItem in ItemsOfNinja)
                {
                    Item thisItem = _db.Items.Find(ninjaItem.ItemId);
                    if (thisItem.CategoryId == item.CategoryId) 
                    {
                        SellItem(item.Id, ninja.Id);
                    }
                }
            }
        }

        private void SellItemAll(int? id) 
        {
            Item itemToSell = _db.Items.Find(id);
            List<ItemOfNinja> ninjasWithThisItem = _db.ItemOfNinjas.Where(i => i.ItemId == id).ToList();
            List<Ninja> ninjas = new List<Ninja>();
            foreach (var ninja in ninjasWithThisItem)
            {
                ninjas.Add(_db.Ninjas.Find(ninja.NinjaId));
                _db.ItemOfNinjas.Remove(ninja);
            }
            foreach (var ninja in ninjas)
            {
                ninja.Gold += itemToSell.Value;
            }
        }

        private void SellItem(int? itemId, int? ninjaId) 
        {
            Item itemToSell = _db.Items.Find(itemId);
            Ninja ninja = _db.Ninjas.Find(ninjaId);
            ItemOfNinja connection = _db.ItemOfNinjas.Where(i => i.ItemId == itemId && i.NinjaId == ninjaId).First();

            ninja.Gold += itemToSell.Value;
            _db.ItemOfNinjas.Remove(connection);
            _db.SaveChanges();

        }
    }
}