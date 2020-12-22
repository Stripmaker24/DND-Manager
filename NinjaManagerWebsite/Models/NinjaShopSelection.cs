using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class NinjaShopSelection
    {
        public Ninja ninja { get; set; }
        public List<Shop> shops { get; set; }
    }
}
