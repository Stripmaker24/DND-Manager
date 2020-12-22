using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NinjaManagerWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManagerWebsite.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ItemOfNinja> ItemOfNinjas { get; set; }
        public DbSet<ItemOfShop> ItemOfShops { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            ApplicationUser Soramus = new ApplicationUser { UserName = "Soramus", NormalizedUserName = "SORAMUS", PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Saterday@2020")};
            ApplicationUser Stripmaker = new ApplicationUser { UserName = "Stripmaker24", NormalizedUserName = "STRIPMAKER24", PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "24@NinjaManager24")};
            ApplicationUser Michelle = new ApplicationUser { UserName = "Michelle", NormalizedUserName = "MICHELLE", PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "ThisIsMySit3!") };
            
            IdentityRole user = new IdentityRole { Name = "User", NormalizedName = "USER" };
            IdentityRole admin = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };
            IdentityRole owner =  new IdentityRole { Name = "Owner", NormalizedName = "OWNER" };
            
            base.OnModelCreating(builder);
            
            builder.Entity<ItemOfNinja>().HasKey(ion => new { ion.NinjaId, ion.ItemId });
            
            builder.Entity<ItemOfShop>().HasKey(ios => new { ios.ShopId, ios.ItemId });
            
            builder.Entity<IdentityRole>().HasData(user, admin, owner);
            
            builder.Entity<ApplicationUser>().HasData(Soramus, Stripmaker, Michelle);
            
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = user.Id, UserId = Soramus.Id},
                new IdentityUserRole<string> { RoleId = admin.Id, UserId = Stripmaker.Id },
                new IdentityUserRole<string> { RoleId = owner.Id, UserId = Michelle.Id }
                );

            builder.Entity<Ninja>().HasData(
                new Ninja { Id = 1, Name = "Akahri", Gold = 10000, ownerId = Soramus.Id},
                new Ninja { Id = 2, Name = "Drippy", Gold = 10000, ownerId = Soramus.Id },
                new Ninja { Id = 3, Name = "Dublin", Gold = 10000, ownerId = Soramus.Id },
                new Ninja { Id = 4, Name = "Tele-kin", Gold = 10000, ownerId = Soramus.Id },
                new Ninja { Id = 5, Name = "Siggy", Gold = 10000, ownerId = Soramus.Id }
                );

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Head" },
                new Category { Id = 2, Name = "Chest" },
                new Category { Id = 3, Name = "Hand" },
                new Category { Id = 4, Name = "Feet" },
                new Category { Id = 5, Name = "Ring" },
                new Category { Id = 6, Name = "Necklace" }
                );

            builder.Entity<Shop>().HasData(
                new Shop { Id = 1, ShopName = "Gilmore's Glorious Goods" }
                );

            builder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Headband of Intellect", CategoryId = 1, Value = 1500, Intelligence = 20},
                new Item { Id = 2, Name = "Helm of Teleportation", CategoryId = 1, Value = 1100, Dexterity = 15 },
                new Item { Id = 3, Name = "Helm of the Black Dragon", CategoryId = 1, Value = 1200, Strenght = 18 },
                new Item { Id = 4, Name = "Robe of the Archmage", CategoryId = 2, Value = 2200, Dexterity = 15, Intelligence = 10 },
                new Item { Id = 5, Name = "Dwarven Plate", CategoryId = 2, Value = 1800, Dexterity = 10, Strenght = 10 },
                new Item { Id = 6, Name = "Dragon Scale Mail", CategoryId = 2, Value = 2000, Dexterity = -5, Strenght = 22 },
                new Item { Id = 7, Name = "Gauntlets of Ogre Power", CategoryId = 3, Value = 1400, Strenght = 19 },
                new Item { Id = 8, Name = "Gloves of Swimming and Climbing", CategoryId = 3, Value = 1300, Dexterity = 15 },
                new Item { Id = 9, Name = "Thieves touch", CategoryId = 3, Value = 1200, Dexterity = 10, Intelligence = 5 },
                new Item { Id = 10, Name = "Boots of Elvenkind", CategoryId = 4, Value = 1200, Dexterity = 12, Intelligence = 3 },
                new Item { Id = 11, Name = "Slippers of Spider Climbing", CategoryId = 4, Value = 1300, Dexterity = 16 },
                new Item { Id = 12, Name = "Demon Boots", CategoryId = 4, Value = 1100, Dexterity = -5, Strenght = 15},
                new Item { Id = 13, Name = "Ring of Mind Shielding", CategoryId = 5, Value = 1000, Intelligence = 10},
                new Item { Id = 14, Name = "Ring of Jumping", CategoryId = 5, Value = 1100, Dexterity = 13 },
                new Item { Id = 15, Name = "Ring of Protection", CategoryId = 5, Value = 1200, Strenght = 15 },
                new Item { Id = 16, Name = "Necklace of Prayer Beads", CategoryId = 6, Value = 1500, Intelligence = 18 },
                new Item { Id = 17, Name = "Amulet of Health", CategoryId = 6, Value = 1400, Strenght = 16},
                new Item { Id = 18, Name = "Amulet of Speed", CategoryId = 6, Value = 1600, Dexterity = 19 }
                );

            builder.Entity<ItemOfNinja>().HasData(
                new ItemOfNinja { NinjaId = 1, ItemId = 1 },
                new ItemOfNinja { NinjaId = 1, ItemId = 4 },
                new ItemOfNinja { NinjaId = 1, ItemId = 8 },
                new ItemOfNinja { NinjaId = 1, ItemId = 10 },
                new ItemOfNinja { NinjaId = 1, ItemId = 13 },
                new ItemOfNinja { NinjaId = 1, ItemId = 16 }
                );

            builder.Entity<ItemOfShop>().HasData(
                new ItemOfShop { ShopId = 1, ItemId = 1 },
                new ItemOfShop { ShopId = 1, ItemId = 2 },
                new ItemOfShop { ShopId = 1, ItemId = 3 },
                new ItemOfShop { ShopId = 1, ItemId = 4 },
                new ItemOfShop { ShopId = 1, ItemId = 5 },
                new ItemOfShop { ShopId = 1, ItemId = 6 },
                new ItemOfShop { ShopId = 1, ItemId = 7 },
                new ItemOfShop { ShopId = 1, ItemId = 8 },
                new ItemOfShop { ShopId = 1, ItemId = 9 },
                new ItemOfShop { ShopId = 1, ItemId = 10 },
                new ItemOfShop { ShopId = 1, ItemId = 11 },
                new ItemOfShop { ShopId = 1, ItemId = 12 },
                new ItemOfShop { ShopId = 1, ItemId = 13 },
                new ItemOfShop { ShopId = 1, ItemId = 14 },
                new ItemOfShop { ShopId = 1, ItemId = 15 },
                new ItemOfShop { ShopId = 1, ItemId = 16 },
                new ItemOfShop { ShopId = 1, ItemId = 17 },
                new ItemOfShop { ShopId = 1, ItemId = 18 }
                );
        }
    }
}
