using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ShopName { get; set; }
        public ICollection<ItemOfShop> itemOfShops { get; set; }
    }
}
