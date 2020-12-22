using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class CEDItem
    {
        public Item item { get; set; }
        public List<Category> categories { get; set; }
    }
}
