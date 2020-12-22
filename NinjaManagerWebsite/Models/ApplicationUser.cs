using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Ninja> Ninjas { get; set; }
    }
}
