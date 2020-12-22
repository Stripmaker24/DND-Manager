using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class ItemOfNinja
    {
        public int NinjaId { get; set; }
        public Ninja Ninja { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
