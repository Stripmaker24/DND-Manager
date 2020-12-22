using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class ShopSupMenu
    {
        public Shop shop { get; set; }
        public Ninja ninja { get; set; }
        public List<Item> shopInventory { get; set; }
        public List<Item> ninjaInventory { get; set; }
    }
}
