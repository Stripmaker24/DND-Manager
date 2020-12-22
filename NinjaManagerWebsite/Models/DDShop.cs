using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class DDShop
    {
        public Shop Shop { get; set; }
        public List<ItemWithCategory> Inventory { get; set; }
    }
}
