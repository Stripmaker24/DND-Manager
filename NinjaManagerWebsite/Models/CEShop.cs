using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class CEShop
    {
        public Shop shop { get; set; }
        [Display(Name = "Head Items")]
        public List<Item> headItems { get; set; }
        [Display(Name = "Chest Items")]
        public List<Item> chestItems { get; set; }
        [Display(Name = "Hand Items")]
        public List<Item> handItems { get; set; }
        [Display(Name = "Feet Items")]
        public List<Item> feetItems { get; set; }
        [Display(Name = "Ring Items")]
        public List<Item> ringItems { get; set; }
        [Display(Name = "Necklace Items")]
        public List<Item> necklaceItems { get; set; }
        [Range(3,int.MaxValue, ErrorMessage ="Need at least 3 items of this category!")]
        public List<int> selectedHead { get; set; }
        [Range(3, int.MaxValue, ErrorMessage = "Need at least 3 items of this category!")]
        public List<int> selectedChest { get; set; }
        [Range(3, int.MaxValue, ErrorMessage = "Need at least 3 items of this category!")]
        public List<int> selectedHand { get; set; }
        [Range(3, int.MaxValue, ErrorMessage = "Need at least 3 items of this category!")]
        public List<int> selectedFeet { get; set; }
        [Range(3, int.MaxValue, ErrorMessage = "Need at least 3 items of this category!")]
        public List<int> selectedRing { get; set; }
        [Range(3, int.MaxValue, ErrorMessage = "Need at least 3 items of this category!")]
        public List<int> selectedNecklace { get; set; }
    }
}
