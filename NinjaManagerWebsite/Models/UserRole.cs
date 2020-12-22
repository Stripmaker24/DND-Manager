using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Models
{
    public class UserRole
    {
        public string RoleId { get; set; }
        public List<User> Users { get; set; }
    }
}
