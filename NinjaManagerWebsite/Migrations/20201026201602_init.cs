using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaManagerWebsite.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ninjas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Gold = table.Column<int>(nullable: false),
                    ownerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninjas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ninjas_AspNetUsers_ownerId",
                        column: x => x.ownerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Strenght = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOfNinjas",
                columns: table => new
                {
                    NinjaId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOfNinjas", x => new { x.NinjaId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemOfNinjas_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOfNinjas_Ninjas_NinjaId",
                        column: x => x.NinjaId,
                        principalTable: "Ninjas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemOfShops",
                columns: table => new
                {
                    ShopId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemOfShops", x => new { x.ShopId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemOfShops_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemOfShops_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b30d6c9-28f3-42ec-9da3-8fd89ec66259", "b27e03c7-ad8b-4591-9c39-2e8180b093b0", "User", "USER" },
                    { "6766c9e1-7124-417f-93de-ac0ebe1f1af7", "24102c08-9fbe-4d33-9937-954d5f2d073b", "Admin", "ADMIN" },
                    { "66332d17-3989-4bea-a4e1-7fc5b26421b1", "362c13bb-1ff4-4c4f-a437-ef41a1f29906", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1", 0, "58ac0b6c-9379-4295-a49d-f613caa41df9", null, false, false, null, null, "SORAMUS", "AQAAAAEAACcQAAAAEOIs6Uwh+g26WS6FGOvMSZXrmA6yEKqJ4KTF28N6If/XzQBVb/xwJtDLOk+M1GagpQ==", null, false, "9d7833d2-d931-415f-8e42-a50b70682de1", false, "Soramus" },
                    { "40529377-1745-4b2d-8aa1-da50ccc7201c", 0, "78277cc0-0626-455d-92b4-870f347684b0", null, false, false, null, null, "STRIPMAKER24", "AQAAAAEAACcQAAAAEFH87jk4AJjVHGsNPT8AqH41yGTfJ/pUi/s1MH+mDQJ2joE21hid0gO/UtVo6FHcgA==", null, false, "1e81adec-f0d4-419f-ab74-446851a325eb", false, "Stripmaker24" },
                    { "59d4a756-3427-4d7d-92ce-b6653ae5071f", 0, "d1e76811-adb7-4113-8c8b-c3c9c5198444", null, false, false, null, null, "MICHELLE", "AQAAAAEAACcQAAAAEAr6++ETN61jgURQPCIgOcjSgBSq0FImhxAfIpASuW3PVFOb1F97fUBhJC5CskT1CA==", null, false, "836fc9ba-d741-4147-852b-25221973fb96", false, "Michelle" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Head" },
                    { 2, "Chest" },
                    { 3, "Hand" },
                    { 4, "Feet" },
                    { 5, "Ring" },
                    { 6, "Necklace" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "ShopName" },
                values: new object[] { 1, "Gilmore's Glorious Goods" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1", "2b30d6c9-28f3-42ec-9da3-8fd89ec66259" },
                    { "40529377-1745-4b2d-8aa1-da50ccc7201c", "6766c9e1-7124-417f-93de-ac0ebe1f1af7" },
                    { "59d4a756-3427-4d7d-92ce-b6653ae5071f", "66332d17-3989-4bea-a4e1-7fc5b26421b1" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Dexterity", "Intelligence", "Name", "Strenght", "Value" },
                values: new object[,]
                {
                    { 16, 6, 0, 18, "Necklace of Prayer Beads", 0, 1500 },
                    { 15, 5, 0, 0, "Ring of Protection", 15, 1200 },
                    { 14, 5, 13, 0, "Ring of Jumping", 0, 1100 },
                    { 13, 5, 0, 10, "Ring of Mind Shielding", 0, 1000 },
                    { 12, 4, -5, 0, "Demon Boots", 15, 1100 },
                    { 11, 4, 16, 0, "Slippers of Spider Climbing", 0, 1300 },
                    { 10, 4, 12, 3, "Boots of Elvenkind", 0, 1200 },
                    { 9, 3, 10, 5, "Thieves touch", 0, 1200 },
                    { 8, 3, 15, 0, "Gloves of Swimming and Climbing", 0, 1300 },
                    { 7, 3, 0, 0, "Gauntlets of Ogre Power", 19, 1400 },
                    { 5, 2, 10, 0, "Dwarven Plate", 10, 1800 },
                    { 17, 6, 0, 0, "Amulet of Health", 16, 1400 },
                    { 4, 2, 15, 10, "Robe of the Archmage", 0, 2200 },
                    { 3, 1, 0, 0, "Helm of the Black Dragon", 18, 1200 },
                    { 2, 1, 15, 0, "Helm of Teleportation", 0, 1100 },
                    { 1, 1, 0, 20, "Headband of Intellect", 0, 1500 },
                    { 6, 2, -5, 0, "Dragon Scale Mail", 22, 2000 },
                    { 18, 6, 19, 0, "Amulet of Speed", 0, 1600 }
                });

            migrationBuilder.InsertData(
                table: "Ninjas",
                columns: new[] { "Id", "Gold", "Name", "ownerId" },
                values: new object[,]
                {
                    { 5, 10000, "Siggy", "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1" },
                    { 4, 10000, "Tele-kin", "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1" },
                    { 3, 10000, "Dublin", "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1" },
                    { 2, 10000, "Drippy", "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1" },
                    { 1, 10000, "Akahri", "40e3b70b-7a21-4bd6-8bd8-e945b1fc1eb1" }
                });

            migrationBuilder.InsertData(
                table: "ItemOfNinjas",
                columns: new[] { "NinjaId", "ItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 16 },
                    { 1, 4 },
                    { 1, 13 },
                    { 1, 8 },
                    { 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "ItemOfShops",
                columns: new[] { "ShopId", "ItemId" },
                values: new object[,]
                {
                    { 1, 16 },
                    { 1, 15 },
                    { 1, 14 },
                    { 1, 13 },
                    { 1, 12 },
                    { 1, 11 },
                    { 1, 10 },
                    { 1, 9 },
                    { 1, 8 },
                    { 1, 7 },
                    { 1, 6 },
                    { 1, 5 },
                    { 1, 4 },
                    { 1, 3 },
                    { 1, 2 },
                    { 1, 1 },
                    { 1, 17 },
                    { 1, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfNinjas_ItemId",
                table: "ItemOfNinjas",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemOfShops_ItemId",
                table: "ItemOfShops",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ninjas_ownerId",
                table: "Ninjas",
                column: "ownerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ItemOfNinjas");

            migrationBuilder.DropTable(
                name: "ItemOfShops");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ninjas");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
