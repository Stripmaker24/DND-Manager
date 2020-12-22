﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NinjaManagerWebsite.Data;

namespace NinjaManagerWebsite.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "2b30d6c9-28f3-42ec-9da3-8fd89ec66259",
                            ConcurrencyStamp = "b27e03c7-ad8b-4591-9c39-2e8180b093b0",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "6766c9e1-7124-417f-93de-ac0ebe1f1af7",
                            ConcurrencyStamp = "24102c08-9fbe-4d33-9937-954d5f2d073b",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "66332d17-3989-4bea-a4e1-7fc5b26421b1",
                            ConcurrencyStamp = "362c13bb-1ff4-4c4f-a437-ef41a1f29906",
                            Name = "Owner",
                            NormalizedName = "OWNER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1",
                            RoleId = "2b30d6c9-28f3-42ec-9da3-8fd89ec66259"
                        },
                        new
                        {
                            UserId = "40529377-1745-4b2d-8aa1-da50ccc7201c",
                            RoleId = "6766c9e1-7124-417f-93de-ac0ebe1f1af7"
                        },
                        new
                        {
                            UserId = "59d4a756-3427-4d7d-92ce-b6653ae5071f",
                            RoleId = "66332d17-3989-4bea-a4e1-7fc5b26421b1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NinjaManagerWebsite.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "58ac0b6c-9379-4295-a49d-f613caa41df9",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "SORAMUS",
                            PasswordHash = "AQAAAAEAACcQAAAAEOIs6Uwh+g26WS6FGOvMSZXrmA6yEKqJ4KTF28N6If/XzQBVb/xwJtDLOk+M1GagpQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9d7833d2-d931-415f-8e42-a50b70682de1",
                            TwoFactorEnabled = false,
                            UserName = "Soramus"
                        },
                        new
                        {
                            Id = "40529377-1745-4b2d-8aa1-da50ccc7201c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "78277cc0-0626-455d-92b4-870f347684b0",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "STRIPMAKER24",
                            PasswordHash = "AQAAAAEAACcQAAAAEFH87jk4AJjVHGsNPT8AqH41yGTfJ/pUi/s1MH+mDQJ2joE21hid0gO/UtVo6FHcgA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1e81adec-f0d4-419f-ab74-446851a325eb",
                            TwoFactorEnabled = false,
                            UserName = "Stripmaker24"
                        },
                        new
                        {
                            Id = "59d4a756-3427-4d7d-92ce-b6653ae5071f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d1e76811-adb7-4113-8c8b-c3c9c5198444",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "MICHELLE",
                            PasswordHash = "AQAAAAEAACcQAAAAEAr6++ETN61jgURQPCIgOcjSgBSq0FImhxAfIpASuW3PVFOb1F97fUBhJC5CskT1CA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "836fc9ba-d741-4147-852b-25221973fb96",
                            TwoFactorEnabled = false,
                            UserName = "Michelle"
                        });
                });

            modelBuilder.Entity("NinjaManagerWebsite.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Head"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Chest"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hand"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Feet"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ring"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Necklace"
                        });
                });

            modelBuilder.Entity("NinjaManagerWebsite.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strenght")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Dexterity = 0,
                            Intelligence = 20,
                            Name = "Headband of Intellect",
                            Strenght = 0,
                            Value = 1500
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Dexterity = 15,
                            Intelligence = 0,
                            Name = "Helm of Teleportation",
                            Strenght = 0,
                            Value = 1100
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Dexterity = 0,
                            Intelligence = 0,
                            Name = "Helm of the Black Dragon",
                            Strenght = 18,
                            Value = 1200
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Dexterity = 15,
                            Intelligence = 10,
                            Name = "Robe of the Archmage",
                            Strenght = 0,
                            Value = 2200
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Dexterity = 10,
                            Intelligence = 0,
                            Name = "Dwarven Plate",
                            Strenght = 10,
                            Value = 1800
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Dexterity = -5,
                            Intelligence = 0,
                            Name = "Dragon Scale Mail",
                            Strenght = 22,
                            Value = 2000
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Dexterity = 0,
                            Intelligence = 0,
                            Name = "Gauntlets of Ogre Power",
                            Strenght = 19,
                            Value = 1400
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Dexterity = 15,
                            Intelligence = 0,
                            Name = "Gloves of Swimming and Climbing",
                            Strenght = 0,
                            Value = 1300
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Dexterity = 10,
                            Intelligence = 5,
                            Name = "Thieves touch",
                            Strenght = 0,
                            Value = 1200
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 4,
                            Dexterity = 12,
                            Intelligence = 3,
                            Name = "Boots of Elvenkind",
                            Strenght = 0,
                            Value = 1200
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 4,
                            Dexterity = 16,
                            Intelligence = 0,
                            Name = "Slippers of Spider Climbing",
                            Strenght = 0,
                            Value = 1300
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 4,
                            Dexterity = -5,
                            Intelligence = 0,
                            Name = "Demon Boots",
                            Strenght = 15,
                            Value = 1100
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 5,
                            Dexterity = 0,
                            Intelligence = 10,
                            Name = "Ring of Mind Shielding",
                            Strenght = 0,
                            Value = 1000
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 5,
                            Dexterity = 13,
                            Intelligence = 0,
                            Name = "Ring of Jumping",
                            Strenght = 0,
                            Value = 1100
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 5,
                            Dexterity = 0,
                            Intelligence = 0,
                            Name = "Ring of Protection",
                            Strenght = 15,
                            Value = 1200
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 6,
                            Dexterity = 0,
                            Intelligence = 18,
                            Name = "Necklace of Prayer Beads",
                            Strenght = 0,
                            Value = 1500
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 6,
                            Dexterity = 0,
                            Intelligence = 0,
                            Name = "Amulet of Health",
                            Strenght = 16,
                            Value = 1400
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 6,
                            Dexterity = 19,
                            Intelligence = 0,
                            Name = "Amulet of Speed",
                            Strenght = 0,
                            Value = 1600
                        });
                });

            modelBuilder.Entity("NinjaManagerWebsite.Models.ItemOfNinja", b =>
                {
                    b.Property<int>("NinjaId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("NinjaId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemOfNinjas");

                    b.HasData(
                        new
                        {
                            NinjaId = 1,
                            ItemId = 1
                        },
                        new
                        {
                            NinjaId = 1,
                            ItemId = 4
                        },
                        new
                        {
                            NinjaId = 1,
                            ItemId = 8
                        },
                        new
                        {
                            NinjaId = 1,
                            ItemId = 10
                        },
                        new
                        {
                            NinjaId = 1,
                            ItemId = 13
                        },
                        new
                        {
                            NinjaId = 1,
                            ItemId = 16
                        });
                });

            modelBuilder.Entity("NinjaManagerWebsite.Models.ItemOfShop", b =>
                {
                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("ShopId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemOfShops");

                    b.HasData(
                        new
                        {
                            ShopId = 1,
                            ItemId = 1
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 2
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 3
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 4
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 5
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 6
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 7
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 8
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 9
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 10
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 11
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 12
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 13
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 14
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 15
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 16
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 17
                        },
                        new
                        {
                            ShopId = 1,
                            ItemId = 18
                        });
                });

            modelBuilder.Entity("NinjaManagerWebsite.Models.Ninja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ownerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ownerId");

                    b.ToTable("Ninjas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Gold = 10000,
                            Name = "Akahri",
                            ownerId = "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1"
                        },
                        new
                        {
                            Id = 2,
                            Gold = 10000,
                            Name = "Drippy",
                            ownerId = "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1"
                        },
                        new
                        {
                            Id = 3,
                            Gold = 10000,
                            Name = "Dublin",
                            ownerId = "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1"
                        },
                        new
                        {
                            Id = 4,
                            Gold = 10000,
                            Name = "Tele-kin",
                            ownerId = "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1"
                        },
                        new
                        {
                            Id = 5,
                            Gold = 10000,
                            Name = "Siggy",
                            ownerId = "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1"
                        });
                });

            modelBuilder.Entity("NinjaManagerWebsite.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ShopName = "Gilmore's Glorious Goods"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NinjaManagerWebsite.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NinjaManagerWebsite.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NinjaManagerWebsite.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NinjaManagerWebsite.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NinjaManagerWebsite.Models.Item", b =>
                {
                    b.HasOne("NinjaManagerWebsite.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NinjaManagerWebsite.Models.ItemOfNinja", b =>
                {
                    b.HasOne("NinjaManagerWebsite.Models.Item", "Item")
                        .WithMany("itemOfNinjas")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NinjaManagerWebsite.Models.Ninja", "Ninja")
                        .WithMany("itemOfNinjas")
                        .HasForeignKey("NinjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NinjaManagerWebsite.Models.ItemOfShop", b =>
                {
                    b.HasOne("NinjaManagerWebsite.Models.Item", "Item")
                        .WithMany("itemOfShops")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NinjaManagerWebsite.Models.Shop", "Shop")
                        .WithMany("itemOfShops")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NinjaManagerWebsite.Models.Ninja", b =>
                {
                    b.HasOne("NinjaManagerWebsite.Models.ApplicationUser", "owner")
                        .WithMany("Ninjas")
                        .HasForeignKey("ownerId");
                });
#pragma warning restore 612, 618
        }
    }
}
