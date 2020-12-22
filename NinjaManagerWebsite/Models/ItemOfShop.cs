using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class ItemOfShop
    {
        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
