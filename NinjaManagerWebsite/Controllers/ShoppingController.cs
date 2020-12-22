using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NinjaManagerWebsite.Data;
using NinjaManagerWebsite.Models;

namespace NinjaManagerWebsite.Controllers
{
    [Authorize(Roles = "User, Admin, Owner")]
    public class ShoppingController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShoppingController(AppDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index(int? id)
        {
            if (id == 0 || id == null) 
            {
                return RedirectToAction("Index", "Ninja");
            }
            var shoppingNinja = _db.Ninjas.Find(id);
            if (shoppingNinja.ownerId != _userManager.GetUserId(HttpContext.User))
            {
                return NotFound();
            }
            List<Shop> Shops = _db.Shops.ToList();
            return View(new NinjaShopSelection { ninja = shoppingNinja, shops = Shops });
        }

        public IActionResult ShopMenu(int? shopId, int? ninjaId) 
        {
            if (shopId == 0 || shopId == null || ninjaId == 0 || ninjaId == null) 
            {
                return RedirectToAction("Index");
            }
            Shop shop = _db.Shops.Find(shopId);
            Ninja ninja = _db.Ninjas.Find(ninjaId);
            if (shop == null || ninja == null) 
            {
                return RedirectToAction("Index");
            }
            if (ninja.ownerId != _userManager.GetUserId(HttpContext.User))
            {
                return NotFound();
            }
            return View(new ShopMenu { ninja = ninja, shop = shop });
        }
        //GET - SHOPAT
        public IActionResult ShopAt(int? Id, int? shopId, int? ninjaId, string? err) 
        {
            if (Id == null || Id == 0 || shopId == null || shopId == 0 || ninjaId == null || ninjaId == 0)
            {
                return RedirectToAction("Index");
            }
            if (err != null) 
            {
                ModelState.AddModelError(string.Empty, err);
            }
            Ninja myNinja = _db.Ninjas.Include("itemOfNinjas").Where(n => n.Id == ninjaId).First();
            Shop myShop = _db.Shops.Include("itemOfShops").Where(s => s.Id == shopId).First();
            if (myNinja.ownerId != _userManager.GetUserId(HttpContext.User))
            {
                return NotFound();
            }
            List<Item> _ninjaInventory = new List<Item>();
            List<Item> _shopInventory = new List<Item>();

            switch (Id)
            {
                case 1:
                    foreach (var item in myNinja.itemOfNinjas)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 1) 
                        {
                            _ninjaInventory.Add(tempItem);
                        }
                    }
                    foreach (var item in myShop.itemOfShops)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 1)
                        {
                            _shopInventory.Add(tempItem);
                        }
                    }
                    break;
                case 2:
                    foreach (var item in myNinja.itemOfNinjas)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 2)
                        {
                            _ninjaInventory.Add(tempItem);
                        }
                    }
                    foreach (var item in myShop.itemOfShops)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 2)
                        {
                            _shopInventory.Add(tempItem);
                        }
                    }
                    break;
                case 3:
                    foreach (var item in myNinja.itemOfNinjas)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 3)
                        {
                            _ninjaInventory.Add(tempItem);
                        }
                    }
                    foreach (var item in myShop.itemOfShops)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 3)
                        {
                            _shopInventory.Add(tempItem);
                        }
                    } 
                    break;
                case 4:
                    foreach (var item in myNinja.itemOfNinjas)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 4)
                        {
                            _ninjaInventory.Add(tempItem);
                        }
                    }
                    foreach (var item in myShop.itemOfShops)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 4)
                        {
                            _shopInventory.Add(tempItem);
                        }
                    }
                    break;
                case 5:
                    foreach (var item in myNinja.itemOfNinjas)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 5)
                        {
                            _ninjaInventory.Add(tempItem);
                        }
                    }
                    foreach (var item in myShop.itemOfShops)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 5)
                        {
                            _shopInventory.Add(tempItem);
                        }
                    }
                    break;
                case 6:
                    foreach (var item in myNinja.itemOfNinjas)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 6)
                        {
                            _ninjaInventory.Add(tempItem);
                        }
                    }
                    foreach (var item in myShop.itemOfShops)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        if (tempItem.CategoryId == 6)
                        {
                            _shopInventory.Add(tempItem);
                        }
                    }
                    break;
                case 7:
                    foreach (var item in myNinja.itemOfNinjas)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        _ninjaInventory.Add(tempItem);
                    }
                    foreach (var item in myShop.itemOfShops)
                    {
                        var tempItem = _db.Items.Find(item.ItemId);
                        _shopInventory.Add(tempItem);
                    }
                    ShopSupMenu _shopSupMenu = new ShopSupMenu { ninja = myNinja, shop = myShop, ninjaInventory = _ninjaInventory, shopInventory = _shopInventory };
                    return View("ShopSell", _shopSupMenu);
                default:
                    return RedirectToAction("Index");
            }

            return View(new ShopSupMenu { ninja = myNinja, shop = myShop, ninjaInventory = _ninjaInventory, shopInventory = _shopInventory });
        }

        //POST - SHOPSELL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShopSell(int? itemId, int? ninjaId, int? shopId) 
        {
            if (itemId == null || itemId == 0 || ninjaId == null || ninjaId == 0)
            {
                return RedirectToAction("Index");
            }
            SellItem(itemId, ninjaId);
            return RedirectToAction("ShopAt", new { Id = 7, ninjaId = ninjaId, shopId = shopId});
        }
        //POST - SHOPBUY
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShopBuy(int? itemId, int? ninjaId, int? shopId) 
        {
            Item itemToBuy = _db.Items.Find(itemId);
            if (itemId == null || itemId == 0 || ninjaId == null || ninjaId == 0)
            {
                return RedirectToAction("Index");
            }
            string err = BuyItem(itemId, ninjaId);
            if ( err == null)
            {
                return RedirectToAction("ShopAt", new { Id = itemToBuy.CategoryId, ninjaId = ninjaId, shopId = shopId });
            }
            else 
            {
                return RedirectToAction("ShopAt", new { Id = itemToBuy.CategoryId, ninjaId = ninjaId, shopId = shopId, err = err });
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

        private string BuyItem(int? itemId, int? ninjaId) 
        {
            Item itemToBuy = _db.Items.Find(itemId);
            List<Ninja> ninjas = _db.Ninjas.Include("itemOfNinjas").ToList();
            Ninja ninja = ninjas.Where(n => n.Id == ninjaId).First();
            if (ninja.itemOfNinjas.Count() != 0) 
            {
                foreach (var item in ninja.itemOfNinjas)
                {
                    var tempItem = _db.Items.Find(item.ItemId);
                    if (tempItem.CategoryId == itemToBuy.CategoryId) 
                    {
                        return "Cannot buy this item: Already have a Item of this kind!";
                    }
                }
            }
            ItemOfNinja connection = new ItemOfNinja { NinjaId = ninja.Id, ItemId = itemToBuy.Id };
            if (ninja.Gold - itemToBuy.Value < 0) 
            {
                return "Cannot buy this item: Not enough gold!";
            }
            ninja.Gold -= itemToBuy.Value;
            _db.ItemOfNinjas.Add(connection);
            _db.SaveChanges();
            return null; 
        }
    }
}