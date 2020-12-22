using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class NinjaInventory
    {
        public Ninja Ninja { get; set; }
        public ItemWithCategory headItem { get; set; }
        public ItemWithCategory chestItem { get; set; }
        public ItemWithCategory handItem { get; set; }
        public ItemWithCategory feetItem { get; set; }
        public ItemWithCategory ringItem { get; set; }
        public ItemWithCategory necklaceItem { get; set; }
        [Display(Name = "Ninja Strength")]
        public int totalStr { get; set; }
        [Display(Name = "Ninja Intelligence")]
        public int totalInt { get; set; }
        [Display(Name = "Ninja Dexterity")]
        public int totalDex { get; set; }
        [Display(Name = "Value of Equipment")]
        public int totalItemValue { get; set; }
    }
}
