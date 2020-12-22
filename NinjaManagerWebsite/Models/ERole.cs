using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class ERole
    {
        public ERole()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
