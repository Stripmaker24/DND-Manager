using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Value in gold")]
        [Required]
        public int Value { get; set; }
        [DisplayName("Type of item")]
        public Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [DisplayName("STR")]
        public int Strenght { get; set; }
        [DisplayName("DEX")]
        public int Dexterity { get; set; }
        [DisplayName("INT")]
        public int Intelligence { get; set; }
        public ICollection<ItemOfNinja> itemOfNinjas { get; set; }
        public ICollection<ItemOfShop> itemOfShops { get; set; }
    }
}
