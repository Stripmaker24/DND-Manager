using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class Ninja
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Amount of gold")]
        [Required]
        [Range(0,int.MaxValue,ErrorMessage ="Amount of gold must be 0 or greater")]
        public int Gold { get; set; }
        public ICollection<ItemOfNinja> itemOfNinjas { get; set; }

        public ApplicationUser owner { get; set; }
        public string ownerId { get; set; }
    }
}
