using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using NinjaManagerWebsite.Data;
using NinjaManagerWebsite.Models;
using Microsoft.AspNetCore.Authorization;

namespace NinjaManagerWebsite.Controllers
{
    [Authorize(Roles = "Admin, Owner")]
    public class ShopController : Controller
    {
        private readonly AppDbContext _db;
        private List<Item> head;
        private List<Item> chest;
        private List<Item> hand;
        private List<Item> feet;
        private List<Item> ring;
        private List<Item> necklace;
        public ShopController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Shop> objList = _db.Shops;
            return View(objList);
        }

        // GET - CREATE
        public IActionResult Create() 
        {
            var obj = new Shop();
            RefreshItems();
            CEShop newShop = new CEShop
            {
                shop = obj,
                headItems = head,
                chestItems = chest,
                handItems = hand,
                feetItems = feet,
                ringItems = ring,
                necklaceItems = necklace,
                selectedHead = new List<int>(),
                selectedChest = new List<int>(),
                selectedHand = new List<int>(),
                selectedFeet = new List<int>(),
                selectedRing = new List<int>(),
                selectedNecklace = new List<int>()
            };
            return View(newShop);
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CEShop ceShop) 
        {
            List<string> errString = CheckAmountOfItems(ceShop);
            if (errString.Count > 0) 
            {
                foreach (var err in errString)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
                RefreshItems();
                return View(ResetCreateShop(ceShop));
            }
                SaveShops(ceShop);
                _db.SaveChanges();
                return RedirectToAction("Index");

        }

        //GET - EDIT
        public IActionResult Edit(int? id) 
        {
            if (id == 0) 
            {
                return RedirectToAction("Index");
            }
            Shop shop = _db.Shops.Find(id);
            if (shop == null)
            {
                return RedirectToAction("Index");
            }
            RefreshItems();
            List<ItemOfShop> Inventory = _db.ItemOfShops.Where(i => i.ShopId == shop.Id).ToList();
            CEShop newShop = new CEShop { 
                shop = shop, 
                headItems = head, 
                chestItems = chest, 
                handItems = hand, 
                feetItems = feet,
                ringItems = ring, 
                necklaceItems = necklace,
                selectedHead = GetSelectedHead(Inventory),
                selectedChest = GetSelectedChest(Inventory),
                selectedHand = GetSelectedHand(Inventory),
                selectedFeet = GetSelectedFeet(Inventory),
                selectedRing = GetSelectedRing(Inventory),
                selectedNecklace = GetSelectedNecklace(Inventory)
            };
            return View(newShop);
        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CEShop ceShop) 
        {
            List<string> errString = CheckAmountOfItems(ceShop);
            if (errString.Count > 0)
            {
                foreach (var err in errString)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
                RefreshItems();
                return View(ResetCreateShop(ceShop));
            }
            SaveShops(ceShop);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET - DELETE
        public IActionResult Delete(int? id, string err)
        {
            if (err != null)
            {
                ModelState.AddModelError(string.Empty, err);
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var shop = _db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }
            List<ItemOfShop> Items = _db.ItemOfShops.Where(i => i.ShopId == shop.Id).ToList();
            List<int> ItemIds = new List<int>();
            foreach (var item in Items)
            {
                ItemIds.Add(item.ItemId);
            }
            List<ItemWithCategory> ShopItems = new List<ItemWithCategory>();
            foreach (var itemId in ItemIds)
            {
                ShopItems.Add(new ItemWithCategory
                {
                    item = _db.Items.Find(itemId),
                    category = _db.Categories.Find(_db.Items.Find(itemId).CategoryId)
                });
            }

            DDShop DeleteShop = new DDShop { Shop = shop, Inventory = ShopItems };

            return View(DeleteShop);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePerm(DDShop deleteShop) 
        {
            var obj = _db.Shops.Find(deleteShop.Shop.Id);
            if (obj == null)
            {
                return NotFound();
            }
            List<Shop> shops = _db.Shops.ToList();
            if (shops.Count() == 1)
            {
                return RedirectToAction("Delete", new { id = deleteShop.Shop.Id, err = "Can not destroy this shop: ninja's need to buy their gear somewhere!" });
            }
            _db.ItemOfShops.RemoveRange(_db.ItemOfShops.Where(i => i.ShopId == obj.Id).ToList());
            _db.Shops.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET - DETAILS
        public IActionResult Detail(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var shop = _db.Shops.Find(id);
            if (shop == null)
            {
                return NotFound();
            }
            List<ItemOfShop> Items = _db.ItemOfShops.Where(i => i.ShopId == shop.Id).ToList();
            List<int> ItemIds = new List<int>();
            foreach (var item in Items)
            {
                ItemIds.Add(item.ItemId);
            }
            List<ItemWithCategory> ShopItems = new List<ItemWithCategory>();
            foreach (var itemId in ItemIds)
            {
                ShopItems.Add(new ItemWithCategory 
                    {
                        item = _db.Items.Find(itemId), 
                        category = _db.Categories.Find(_db.Items.Find(itemId).CategoryId) 
                    }
                );
            }

            DDShop DetailShop = new DDShop { Shop = shop, Inventory = ShopItems };

            return View(DetailShop);
        }

        private void SaveShops(CEShop ceShop)
        {
            Shop shop;
            List<ItemOfShop> shopList = new List<ItemOfShop>();
            if (ceShop.shop.Id == 0)
            {
                shop = new Shop();
                _db.Shops.Add(shop);
            }
            else 
            {
                shop = _db.Shops.Include("itemOfShops")
                        .First(s => s.Id == ceShop.shop.Id);
                _db.ItemOfShops.RemoveRange(_db.ItemOfShops.Where(i => i.ShopId == shop.Id).ToList());
            }

            shop.ShopName = ceShop.shop.ShopName;
            _db.SaveChanges();
            var AllItems = ceShop.selectedHead.Concat(ceShop.selectedChest)
                                               .Concat(ceShop.selectedHand)
                                               .Concat(ceShop.selectedFeet)
                                               .Concat(ceShop.selectedRing)
                                               .Concat(ceShop.selectedNecklace);
            foreach (var item in AllItems)
            {
                shopList.Add(new ItemOfShop { ShopId = shop.Id, ItemId = item });
            }

            _db.ItemOfShops.AddRange(shopList);
        }

        private void RefreshItems() 
        {
            head = _db.Items.Where(i => i.CategoryId == 1).ToList();
            chest = _db.Items.Where(i => i.CategoryId == 2).ToList();
            hand = _db.Items.Where(i => i.CategoryId == 3).ToList();
            feet = _db.Items.Where(i => i.CategoryId == 4).ToList();
            ring = _db.Items.Where(i => i.CategoryId == 5).ToList();
            necklace = _db.Items.Where(i => i.CategoryId == 6).ToList();
        }

        private CEShop ResetCreateShop(CEShop ceShop) 
        {
            ceShop.headItems = head;
            ceShop.chestItems = chest;
            ceShop.handItems = hand;
            ceShop.feetItems = feet;
            ceShop.ringItems = ring;
            ceShop.necklaceItems = necklace;

            return ceShop;
        }

        private List<string> CheckAmountOfItems(CEShop ceShop) 
        {
            List<string> errStrings = new List<string>();
            if (ceShop.selectedHead == null || ceShop.selectedHead.Count < 3){ errStrings.Add("Not enough Head-Items to open shop!"); }
            if (ceShop.selectedChest == null || ceShop.selectedChest.Count < 3) { errStrings.Add("Not enough Chest-Items to open shop!"); }
            if (ceShop.selectedHand == null || ceShop.selectedHand.Count < 3) { errStrings.Add("Not enough Hand-Items to open shop!"); }
            if (ceShop.selectedFeet == null || ceShop.selectedFeet.Count < 3) { errStrings.Add("Not enough Feet-Items to open shop!"); }
            if (ceShop.selectedRing == null || ceShop.selectedRing.Count < 3) { errStrings.Add("Not enough Ring-Items to open shop!"); }
            if (ceShop.selectedNecklace == null || ceShop.selectedNecklace.Count < 3) { errStrings.Add("Not enough Necklace-Items to open shop!"); }

            return errStrings;
        }

        private List<int> GetSelectedHead(List<ItemOfShop> inventory) 
        {
            List<int> selectedItems = new List<int>();
            foreach (var item in inventory)
            {
                foreach (var head in head)
                {
                    if (head.Id == item.ItemId)
                    {
                        selectedItems.Add(item.ItemId);
                    }
                }
            }
            return selectedItems;
        }

        private List<int> GetSelectedChest(List<ItemOfShop> inventory)
        {
            List<int> selectedItems = new List<int>();
            foreach (var item in inventory)
            {
                foreach (var chest in chest)
                {
                    if (chest.Id == item.ItemId)
                    {
                        selectedItems.Add(item.ItemId);
                    }
                }
            }
            return selectedItems;
        }

        private List<int> GetSelectedHand(List<ItemOfShop> inventory)
        {
            List<int> selectedItems = new List<int>();
            foreach (var item in inventory)
            {
                foreach (var hand in hand)
                {
                    if (hand.Id == item.ItemId)
                    {
                        selectedItems.Add(item.ItemId);
                    }
                }
            }
            return selectedItems;
        }

        private List<int> GetSelectedFeet(List<ItemOfShop> inventory)
        {
            List<int> selectedItems = new List<int>();
            foreach (var item in inventory)
            {
                foreach (var feet in feet)
                {
                    if (feet.Id == item.ItemId)
                    {
                        selectedItems.Add(item.ItemId);
                    }
                }
            }
            return selectedItems;
        }

        private List<int> GetSelectedRing(List<ItemOfShop> inventory)
        {
            List<int> selectedItems = new List<int>();
            foreach (var item in inventory)
            {
                foreach (var ring in ring)
                {
                    if (ring.Id == item.ItemId)
                    {
                        selectedItems.Add(item.ItemId);
                    }
                }
            }
            return selectedItems;
        }

        private List<int> GetSelectedNecklace(List<ItemOfShop> inventory)
        {
            List<int> selectedItems = new List<int>();
            foreach (var item in inventory)
            {
                foreach (var necklace in necklace)
                {
                    if (necklace.Id == item.ItemId)
                    {
                        selectedItems.Add(item.ItemId);
                    }
                }
            }
            return selectedItems;
        }
    }
}