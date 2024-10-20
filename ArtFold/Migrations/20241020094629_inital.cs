using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtFold.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Carts",
                columns: table => new
                {
                    CartID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckOuts",
                columns: table => new
                {
                    CheckOutID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOuts", x => x.CheckOutID);
                    table.ForeignKey(
                        name: "FK_CheckOuts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrintPaperType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    CartID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCartQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.CartID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckOutProducts",
                columns: table => new
                {
                    CheckOutProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckOutID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOutProducts", x => x.CheckOutProductID);
                    table.ForeignKey(
                        name: "FK_CheckOutProducts_CheckOuts_CheckOutID",
                        column: x => x.CheckOutID,
                        principalTable: "CheckOuts",
                        principalColumn: "CheckOutID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckOutProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageID);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentsImage",
                columns: table => new
                {
                    CommentImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsImage", x => x.CommentImageID);
                    table.ForeignKey(
                        name: "FK_CommentsImage_Comments_CommentID",
                        column: x => x.CommentID,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "027b4239-5c02-45ff-91f7-2b36b959dcac", null, "Admin", "ADMIN" },
                    { "5a0710af-80e4-4bea-8950-cd6e46bb17eb", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "CreatedAt", "District", "Email", "EmailConfirmed", "FullName", "HouseAddress", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Ward" },
                values: new object[,]
                {
                    { "3e6ae8dd-acee-4bb1-be78-e29e0bd90117", 0, null, "a35017a1-a706-4cf0-b1eb-a1728754c4bc", new DateTime(2024, 10, 20, 16, 46, 28, 178, DateTimeKind.Local).AddTicks(9407), null, "taimodel@gmail.com", true, "Nguyễn Lương Tài", null, false, null, null, null, "AQAAAAIAAYagAAAAEAWhDCKAcBuPB9WyloieBG+uOg7QLrRnKMo8U+xJucnZEvGKUOG9uZ6IDdAT3JEuAA==", "0123456789", false, "a16126b8-c730-4db3-8976-f6d2c6e5aad2", false, "TaiModel", null },
                    { "6ad7fd42-d7ef-4051-8c56-298b31fbf498", 0, null, "b23e1a0a-ad4e-4ae0-b630-d8d5b6536666", new DateTime(2024, 10, 20, 16, 46, 28, 455, DateTimeKind.Local).AddTicks(5424), null, "thuIT@gmail.com", true, "Thư AI", null, false, null, null, null, "AQAAAAIAAYagAAAAEHIHsGH2+JekcJ3cjXYcLAU/2J6AG/zFH0bMsDgTbzPReMKMw/acsT+SMHWVpprY7A==", "0123456789", false, "d8b4a13a-bb74-4778-b524-4f501f22ea2e", false, "ThuIT", null },
                    { "a19f9cfb-702d-408e-a286-bc70a904c670", 0, null, "f5e483a0-ddbf-4add-b5b4-e43dc2ebf0cf", new DateTime(2024, 10, 20, 16, 46, 28, 241, DateTimeKind.Local).AddTicks(9023), null, "dinhuynhminhthu@gmail.com", true, "Đinh Huỳnh Minh Thư", null, false, null, null, null, "AQAAAAIAAYagAAAAEOSKK3IYaDe8B/tkIbIG1BvrSZAdWhKxkmT8SIdF6VwMTeZaNr057UAcmklucJA48g==", "0123456789", false, "8946304d-008b-4937-92c1-14d0b5996fe9", false, "MinhThu", null },
                    { "b4b9de23-032d-4e8c-b5e4-5252170b0782", 0, null, "8adbfc28-8696-4665-86bd-ffa8f7681780", new DateTime(2024, 10, 20, 16, 46, 28, 116, DateTimeKind.Local).AddTicks(3384), null, "bluegameming292003@gmail.com", true, "Trần Minh Quốc Khánh", null, false, null, null, null, "AQAAAAIAAYagAAAAEH+XKXZhEGtsTcNoIPYXcCQJUHstZ7Y024Joz9xNWwi9jW4sBSPGlOIyOwjVl7gVew==", "0934763210", false, "014d9adc-fbec-43a8-9784-c26f6e60f38d", false, "Admin", null },
                    { "bbc7362d-86a5-476c-9a8b-28d3a7ae2ffa", 0, null, "7ea46694-1a19-456c-9258-4a8bd5446fe1", new DateTime(2024, 10, 20, 16, 46, 28, 376, DateTimeKind.Local).AddTicks(8644), null, "nguyenvungochan@gmail.com", true, "Nguyễn Vũ Ngọc Hân", null, false, null, null, null, "AQAAAAIAAYagAAAAEO1DVWcbiJly4ABoWROMEggrzzqlvXAImFzw3CjJ03HFjoRLZ46AACu/LFXBKvxK/w==", "0123456789", false, "b778313f-3a9c-4416-b42f-6237abf071d8", false, "NgocHan", null },
                    { "d6385c86-d027-48e3-bbc8-3855e4f8109d", 0, null, "b5e7a4df-afe0-42ac-865d-89b2c720c349", new DateTime(2024, 10, 20, 16, 46, 28, 305, DateTimeKind.Local).AddTicks(9737), null, "ngocha@gmail.com", true, "Ngọc Hà", null, false, null, null, null, "AQAAAAIAAYagAAAAEEIFlYbZxw27CnbhrYLYld/dFhtapbwchkX3F3LGuhsJReicjL/ZAJe1xm8RW7sLOw==", "0123456789", false, "44d4480d-59db-45b5-a923-38629325af21", false, "NgocHa", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("8a0615ab-277b-413a-ab81-ef9ec394f129"), "Anime" },
                    { new Guid("b43d692b-01e5-47cb-9d80-102f821b6ff4"), "Architecture" },
                    { new Guid("c1660c5c-bcd1-449a-8930-7bd6176eb812"), "Marvel" },
                    { new Guid("f6051227-b33a-4a5e-86f8-e5df6aac1dcc"), "Vehicle" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5a0710af-80e4-4bea-8950-cd6e46bb17eb", "3e6ae8dd-acee-4bb1-be78-e29e0bd90117" },
                    { "5a0710af-80e4-4bea-8950-cd6e46bb17eb", "6ad7fd42-d7ef-4051-8c56-298b31fbf498" },
                    { "5a0710af-80e4-4bea-8950-cd6e46bb17eb", "a19f9cfb-702d-408e-a286-bc70a904c670" },
                    { "027b4239-5c02-45ff-91f7-2b36b959dcac", "b4b9de23-032d-4e8c-b5e4-5252170b0782" },
                    { "5a0710af-80e4-4bea-8950-cd6e46bb17eb", "bbc7362d-86a5-476c-9a8b-28d3a7ae2ffa" },
                    { "5a0710af-80e4-4bea-8950-cd6e46bb17eb", "d6385c86-d027-48e3-bbc8-3855e4f8109d" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartID", "UserID" },
                values: new object[,]
                {
                    { new Guid("00cd4a80-0dda-418e-9e9c-641f886369c6"), "a19f9cfb-702d-408e-a286-bc70a904c670" },
                    { new Guid("0d7e3155-2ad5-4d74-ba79-dc6c16be0cae"), "b4b9de23-032d-4e8c-b5e4-5252170b0782" },
                    { new Guid("710f41d4-b874-4c4f-9234-34630055a14d"), "6ad7fd42-d7ef-4051-8c56-298b31fbf498" },
                    { new Guid("85360493-387d-469a-ba23-e32871578da8"), "d6385c86-d027-48e3-bbc8-3855e4f8109d" },
                    { new Guid("b468c633-a8ce-463b-ab35-2cee45207799"), "3e6ae8dd-acee-4bb1-be78-e29e0bd90117" },
                    { new Guid("fefd6342-c1f2-4b4c-9709-ea66a3b39837"), "bbc7362d-86a5-476c-9a8b-28d3a7ae2ffa" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "CreatedAt", "Description", "ImgUrl", "Name", "Price", "PrintPaperType", "ProductQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0f27a49e-b172-4aef-93d7-07aed4d7eb61"), new Guid("c1660c5c-bcd1-449a-8930-7bd6176eb812"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9859), "Bộ sản phẩm Mô hình giấy Marvel Avengers Iron Spider bao gồm:\r\n- 15 tờ kit mô hình.\r\n- Kích thước: Cao: 38cm x Rộng: 30,7cm x Sâu: 34,5cm", "https://down-vn.img.susercontent.com/file/4b925257b8c606d8ba5549860b146ad1.webp", "Marvel Avengers Iron Spider", 100000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9866) },
                    { new Guid("13c64d5c-de4b-4691-86b1-054d2dccea3d"), new Guid("c1660c5c-bcd1-449a-8930-7bd6176eb812"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9882), "Bộ sản phẩm Mô hình giấy Anime Game Chibi Doctor Strange - Marvel bao gồm:\r\n- 2 tờ kit mô hình + kèm scan code xem video hướng dẫn lắp ráp.\r\n* Xuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lzad737x2krla7@resize_w450_nl.webp", "Chibi Doctor Strange", 25000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9883) },
                    { new Guid("22da34e9-b6da-4f99-ae4f-148c3558690b"), new Guid("b43d692b-01e5-47cb-9d80-102f821b6ff4"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9903), "Bộ sản phẩm Mô hình giấy kiến trúc Pháp tháp Eiffel Tower bao gồm:\r\n- 9 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/a077c0d85e3866a441e4b1e76ab69dbb.webp", "Eiffel Tower", 60000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9904) },
                    { new Guid("31135c3a-4ba3-4286-a55b-95f3fc144d98"), new Guid("b43d692b-01e5-47cb-9d80-102f821b6ff4"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9909), "Bộ sản phẩm Mô hình giấy kiến trúc Cambuchia Angkor Wat bao gồm:\r\n- 24 tờ kit mô hình.\r\n- 3 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/edb6286c7abf2d62a36a911b5d0983d4.webp", "Cambuchia Angkor Wat", 156000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9910) },
                    { new Guid("37b7bfff-1b65-4bec-84b2-77a094ca8d2d"), new Guid("8a0615ab-277b-413a-ab81-ef9ec394f129"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9770), "Bộ sản phẩm Mô hình giấy Anime Game Pokemon Pikachu Polygon ver 2 bao gồm:\r\n- 9 tờ kit mô hình in mực Dầu trên giấy Màu.\r\n- 4 tờ hướng dẫn lắp ráp.\r\n- Kích thước A4: Cao: 33cm x Rộng: 30cm x Sâu: 34cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-ls9lvceatuah97@resize_w450_nl.webp", "Pikachu Polygon ver 2", 59000.0, "A4", 30, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9771) },
                    { new Guid("3bd640d9-6303-4601-8ac9-36e40be00de1"), new Guid("c1660c5c-bcd1-449a-8930-7bd6176eb812"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9832), "Bộ sản phẩm Mô hình giấy Marvel Avenger Robot Iron Man Mark VII bao gồm:\r\n- 16 tờ kit mô hình.\r\n- 3 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/5fc4fc6d877bc7c905b6f92eeb951a94.webp", "Robot Iron Man Mark VII", 105000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9833) },
                    { new Guid("4096ead6-de44-45e5-afc9-80701335804f"), new Guid("f6051227-b33a-4a5e-86f8-e5df6aac1dcc"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9822), "Bộ sản phẩm Mô hình giấy máy bay Boeing 777-200 British Airways bao gồm:\r\n- 8 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/a09cfa936019a5e6c493acafbd4a13e1.webp", "Boeing 777-200 British Airways", 58000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9823) },
                    { new Guid("4f626bd2-e681-42b7-b36a-e029b3a9e215"), new Guid("8a0615ab-277b-413a-ab81-ef9ec394f129"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9758), "Bộ sản phẩm Mô hình giấy Anime Chibi Monkey D Luffy - One Piece bao gồm:\r\n- 18 tờ kit mô hình.\r\n- Kích thước: Cao: 40cm x Rộng: 23,4cm x Sâu: 21,6cm", "https://down-vn.img.susercontent.com/file/e82a586f3d146ea83a3b6303b4668914.webp", "Monkey D. Luffy", 55000.0, "A4", 100, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9758) },
                    { new Guid("51bc5c8f-081b-4f11-9bde-82cb86342817"), new Guid("b43d692b-01e5-47cb-9d80-102f821b6ff4"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9916), "Bộ sản phẩm Mô hình giấy kiến trúc Nhà thờ chính Siena Cathedral - Italy bao gồm:\r\n- 19 tờ kit mô hình.\r\n- 4 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/e7ac1e43b3160334e9ca1fc66da7f34a.webp", "Siena Cathedral - Italy", 124000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9917) },
                    { new Guid("5bc5501a-b37f-4995-97a5-a30f6b785422"), new Guid("c1660c5c-bcd1-449a-8930-7bd6176eb812"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9838), "Bộ sản phẩm Mô hình giấy Anime Game Chibi Thor mập - Marvel bao gồm:\r\n- 8 tờ kit mô hình in mực Dầu trên giấy Màu.\r\n- 2 tờ hướng dẫn lắp ráp.\r\n- Kích thước : Cao 15,5cm x Rộng 13cm x Sâu 9cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmua3ev8pza778.webp", "Chibi Thor ", 50000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9838) },
                    { new Guid("6925d956-209d-437e-a34b-a5d1af544f61"), new Guid("f6051227-b33a-4a5e-86f8-e5df6aac1dcc"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9808), "Bộ sản phẩm Mô hình giấy xe ô tô Prototype Technology Group BMW bao gồm:\r\n- 6 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/9fb112bf0fe8b6b773c0aa7411a2392c.webp", "Prototype Technology Group BMW", 79000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9808) },
                    { new Guid("6c53b7c7-b37d-4acc-998b-2571a0d82819"), new Guid("8a0615ab-277b-413a-ab81-ef9ec394f129"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9763), "Bộ sản phẩm Mô hình giấy Anime Game Uzumaki Naruto ver 3 bao gồm:\r\n- 6 tờ kit mô hình.\r\n(Mặc định bản kit sẽ được in bản có line, nếu bạn muốn in bản ko line trong đơn hàng bạn ghi chú là \"in bản ko line\" để shop cho in nhé)\r\n- Kích thước A4: Cao: 17cm x Rộng: 20,1cm x Sâu: 28,3cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/sg-11134201-22110-igsmlbzefhkvf0.webp", "Uzumaki Naruto", 42000.0, "A4", 30, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9764) },
                    { new Guid("8c18462f-549a-46e9-9e2b-bd1e8300ba15"), new Guid("f6051227-b33a-4a5e-86f8-e5df6aac1dcc"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9790), "Bộ sản phẩm Mô hình giấy phi thuyền không gian vũ trụ tàu con thoi Space Shuttle Atlantis bao gồm:\r\n- 11 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/4ed6a6e35f435d28286762c02db7f911.webp", "Space Shuttle Atlantis", 72000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9790) },
                    { new Guid("95815a20-0c65-4018-80df-51528b66aa06"), new Guid("c1660c5c-bcd1-449a-8930-7bd6176eb812"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9843), "Bộ sản phẩm Mô hình giấy Anime Game Marvel Hulk Treo tường ver 3 bao gồm:\r\n– 17 tờ kit mô hình in trên giấy A4 Ford màu định lượng 180gsm (so với giấy photo là 70gsm) + scan code xem hướng dẫn.\r\n- Kích thước: Cao: khoảng 40cm", "https://down-vn.img.susercontent.com/file/8aedf29f64c9de9ac7ec2b3f48182f7b.webp", "Marvel Hulk Wall Hanging", 83000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9844) },
                    { new Guid("96b96a6a-349e-4aba-aab5-f12a7dd2a067"), new Guid("f6051227-b33a-4a5e-86f8-e5df6aac1dcc"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9813), "Bộ sản phẩm Mô hình giấy xe máy Mille Miglia Custom Chopper bao gồm:\r\n- 24 tờ kit mô hình.\r\n- 8 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/2fbbe89ee72a717b7f2bed3a84d8b259.webp", "Mille Miglia Custom Chopper Bike", 149000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9814) },
                    { new Guid("a7be10cd-f374-48d7-afea-bf1f4c2f382f"), new Guid("b43d692b-01e5-47cb-9d80-102f821b6ff4"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9889), "Bộ sản phẩm Mô hình giấy kiến trúc lâu đài Đức Neuschwanstein Castle - Germany bao gồm:\r\n- 8 tờ kit mô hình.\r\n- 2 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/d50b7f9c059c8cb8e7c0654954a08ab1.webp", "Neuschwanstein Castle - Germany", 55000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9890) },
                    { new Guid("ad7e43fb-6ac0-40f4-a802-e13f40813483"), new Guid("b43d692b-01e5-47cb-9d80-102f821b6ff4"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9895), "Bộ sản phẩm Mô hình giấy kiến trúc Tháp Luân Đôn Tower of London – England bao gồm:\r\n- 10 tờ kit mô hình.\r\n- 2 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/5e96e9613e2fd22d255d9d90159d19ce.webp", "Tower of London – England", 65000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9896) },
                    { new Guid("bb2f9a1f-b327-4a7d-b3b4-f2e5318eb7c7"), new Guid("f6051227-b33a-4a5e-86f8-e5df6aac1dcc"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9797), "Bộ sản phẩm Mô hình giấy xe ô tô Lamborghini Sesto Elemento bao gồm:\r\n- 3 tờ kit mô hình.\r\n- Kích thước: Cao: 4,9cm x Rộng: 8,6cm x Sâu: 18,1cm", "https://down-vn.img.susercontent.com/file/966ca26a8de1b2f34c66449cc74e48bd.webp", "Lamborghini Sesto Elemento", 69000.0, "A4", 10, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9798) },
                    { new Guid("d1e9916e-5300-4be3-bb4d-3ba78575d01d"), new Guid("8a0615ab-277b-413a-ab81-ef9ec394f129"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9782), "Bộ sản phẩm Mô hình giấy Anime Chibi Levi Ackerman ver 3 – Attack on Titan bao gồm:\r\n- 6 tờ kit mô hình.\r\n- Kích thước: Cao: 20,3cm x Rộng: 11,1cm x Sâu: 18cm", "https://down-vn.img.susercontent.com/file/a6da3b4677bd9309784051610617a5e7@resize_w450_nl.webp", "Chibi Levi Ackerman", 14000.0, "A4", 80, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9783) },
                    { new Guid("f4771d23-d29d-420c-8834-7f5e64b9e8a0"), new Guid("8a0615ab-277b-413a-ab81-ef9ec394f129"), new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9741), "Bộ sản phẩm Mô hình giấy Anime Goku SSJ HD – Dragon Ball bao gồm:\r\n- 25 tờ kit mô hình.\r\n- Kích thước: Cao: 55,5cm x Rộng: 13,4cm x Sâu: 23,9cm", "https://down-vn.img.susercontent.com/file/ea93877ccd8d3700b6b9ede4220df541.webp", "Son Goku", 50000.0, "A4", 50, new DateTime(2024, 10, 20, 16, 46, 28, 520, DateTimeKind.Local).AddTicks(9745) }
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
                name: "IX_CartProducts_ProductID",
                table: "CartProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserID",
                table: "Carts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutProducts_CheckOutID",
                table: "CheckOutProducts",
                column: "CheckOutID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOutProducts_ProductID",
                table: "CheckOutProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOuts_UserID",
                table: "CheckOuts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductID",
                table: "Comments",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsImage_CommentID",
                table: "CommentsImage",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        /// <inheritdoc />
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
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "CheckOutProducts");

            migrationBuilder.DropTable(
                name: "CommentsImage");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "CheckOuts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
