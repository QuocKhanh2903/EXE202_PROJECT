using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtFold.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
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
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserID",
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
                name: "CheckOuts",
                columns: table => new
                {
                    CheckOutID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOuts", x => x.CheckOutID);
                    table.ForeignKey(
                        name: "FK_CheckOuts_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
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
                name: "OrderProduct",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductID",
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
                    { "2e09c8fc-d898-4f54-8860-e7cd016f61d7", null, "Customer", "CUSTOMER" },
                    { "3fa65a9a-59cc-4a27-83f9-dc477498c2b8", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "30375519-31fe-4714-b3ba-a51ae1732c86", 0, "b4965d14-0995-4098-9ca1-29ba1f7c1a29", new DateTime(2024, 9, 28, 11, 37, 50, 708, DateTimeKind.Local).AddTicks(1764), "ngocha@gmail.com", true, "Ngọc Hà", false, null, null, null, "AQAAAAIAAYagAAAAEIoI7yx2vLQ4vpV7GfYLuXqY75Q5jKmR89/Ct+W90z2yJk93FRLGJ9MTwcLqx2C19g==", "0123456789", false, "4317b928-b1ed-4105-b15b-4663c0416cbe", false, "NgocHa" },
                    { "841c25b5-13fc-4b8c-8092-c8e6420a867d", 0, "b0163405-ed1e-49f4-af65-39e8f2ea568d", new DateTime(2024, 9, 28, 11, 37, 50, 848, DateTimeKind.Local).AddTicks(1786), "thuIT@gmail.com", true, "Thư AI", false, null, null, null, "AQAAAAIAAYagAAAAEAIuboVyoSKzDIbC7qwcm8nBb6bNTpMRxtG/q/Nlahs20abM1tRW5tfmw9F1gC8AcA==", "0123456789", false, "7cc46424-5dd2-4a68-9bf4-04d5771a8d19", false, "ThuIT" },
                    { "a2341b19-59f1-47dc-9cb3-034d7b2bb9f0", 0, "cdd95d27-a949-40c4-a42e-d92950bdf2cc", new DateTime(2024, 9, 28, 11, 37, 50, 500, DateTimeKind.Local).AddTicks(2535), "bluegameming292003@gmail.com", true, "Trần Minh Quốc Khánh", false, null, null, null, "AQAAAAIAAYagAAAAEKxNf1+eHLqCEzNb23bbwg+24gKK3arG3aRRXGrqNNJ5BqjmoydI0W7v416XEDpe4w==", "0934763210", false, "be33c783-a598-4bb9-8561-92ebc6d798df", false, "Admin" },
                    { "cb7dfc70-23fc-4296-a06d-29e9988d84f1", 0, "809b5d2f-e946-4757-bd0e-20e3a28c6b59", new DateTime(2024, 9, 28, 11, 37, 50, 783, DateTimeKind.Local).AddTicks(9921), "nguyenvungochan@gmail.com", true, "Nguyễn Vũ Ngọc Hân", false, null, null, null, "AQAAAAIAAYagAAAAED9y3MYBBFLqaU1LkKHrScgeUOKyXUgW72ufZgg9Pyt7/XalaoBQaEHu/bL65P40bA==", "0123456789", false, "57acb4f3-114c-4274-8616-d3864143333d", false, "NgocHan" },
                    { "e4d911cf-2871-4bac-b548-8e825d8353d6", 0, "e8980e4c-9792-405d-a135-f71c6149ceac", new DateTime(2024, 9, 28, 11, 37, 50, 641, DateTimeKind.Local).AddTicks(221), "dinhuynhminhthu@gmail.com", true, "Đinh Huỳnh Minh Thư", false, null, null, null, "AQAAAAIAAYagAAAAENEmaVCFak+qsTLeKAOJhHmxFNUfM6Kgcv8VSJcKs4Q6+QRuHQssW4Wakb/YzUtL4g==", "0123456789", false, "c4f786bb-5dfb-4bc2-91f4-c30835725b71", false, "MinhThu" },
                    { "e69a1917-b30e-4a75-aa2d-d8718bdb60ae", 0, "0f0025d0-5d7c-4808-bc22-dd15e4623ca7", new DateTime(2024, 9, 28, 11, 37, 50, 563, DateTimeKind.Local).AddTicks(2486), "taimodel@gmail.com", true, "Nguyễn Lương Tài", false, null, null, null, "AQAAAAIAAYagAAAAENw6X6hjX+e/78Hr+2P42PO1IBNMlZnaw9mpIs4D6Bqu3BORss8sBXTUxMW0kZj8AA==", "0123456789", false, "83aeba9c-ebf7-4018-be4a-4244da86db5b", false, "TaiModel" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("51c982ac-e680-4f54-a3de-b265bb164d9d"), "Vehicle" },
                    { new Guid("66aa8768-d7e5-4663-900c-99415f7f0852"), "Architecture" },
                    { new Guid("7db5876e-b1dc-484e-bafc-465b53ec03d7"), "Anime" },
                    { new Guid("f94da136-1534-4561-8177-3c69b1fe708d"), "Marvel" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2e09c8fc-d898-4f54-8860-e7cd016f61d7", "30375519-31fe-4714-b3ba-a51ae1732c86" },
                    { "2e09c8fc-d898-4f54-8860-e7cd016f61d7", "841c25b5-13fc-4b8c-8092-c8e6420a867d" },
                    { "3fa65a9a-59cc-4a27-83f9-dc477498c2b8", "a2341b19-59f1-47dc-9cb3-034d7b2bb9f0" },
                    { "2e09c8fc-d898-4f54-8860-e7cd016f61d7", "cb7dfc70-23fc-4296-a06d-29e9988d84f1" },
                    { "2e09c8fc-d898-4f54-8860-e7cd016f61d7", "e4d911cf-2871-4bac-b548-8e825d8353d6" },
                    { "2e09c8fc-d898-4f54-8860-e7cd016f61d7", "e69a1917-b30e-4a75-aa2d-d8718bdb60ae" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartID", "UserID" },
                values: new object[,]
                {
                    { new Guid("221ff95c-c073-42a7-9434-caf7c9a54755"), "e4d911cf-2871-4bac-b548-8e825d8353d6" },
                    { new Guid("34fc8c48-c213-43e0-a4b0-15f7a4bd23e9"), "e69a1917-b30e-4a75-aa2d-d8718bdb60ae" },
                    { new Guid("4e74dabe-8ca2-4d81-a868-01ec724b7eb8"), "30375519-31fe-4714-b3ba-a51ae1732c86" },
                    { new Guid("74498870-f256-4bea-819f-c37c9b772b72"), "841c25b5-13fc-4b8c-8092-c8e6420a867d" },
                    { new Guid("782e887a-689e-4a95-b4ad-efe44f98cad3"), "cb7dfc70-23fc-4296-a06d-29e9988d84f1" },
                    { new Guid("aa8a7c4c-96b9-47e0-873a-cbf425f34d0c"), "a2341b19-59f1-47dc-9cb3-034d7b2bb9f0" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "CreatedAt", "Description", "ImgUrl", "Name", "Price", "PrintPaperType", "ProductQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0f6e34af-c9b5-43a4-9c6a-119c33453563"), new Guid("f94da136-1534-4561-8177-3c69b1fe708d"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6678), "Bộ sản phẩm Mô hình giấy Marvel Avengers Iron Spider bao gồm:\r\n- 15 tờ kit mô hình.\r\n- Kích thước: Cao: 38cm x Rộng: 30,7cm x Sâu: 34,5cm", "https://down-vn.img.susercontent.com/file/4b925257b8c606d8ba5549860b146ad1.webp", "Marvel Avengers Iron Spider", 100000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6699) },
                    { new Guid("1fd0c45e-070a-4b34-a8d9-ea2c7bed167d"), new Guid("7db5876e-b1dc-484e-bafc-465b53ec03d7"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6513), "Bộ sản phẩm Mô hình giấy Anime Goku SSJ HD – Dragon Ball bao gồm:\r\n- 25 tờ kit mô hình.\r\n- Kích thước: Cao: 55,5cm x Rộng: 13,4cm x Sâu: 23,9cm", "https://down-vn.img.susercontent.com/file/ea93877ccd8d3700b6b9ede4220df541.webp", "Son Goku", 50000.0, "A4", 50, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6518) },
                    { new Guid("2b9005bf-fd83-40c8-b8e9-6734934a7baf"), new Guid("7db5876e-b1dc-484e-bafc-465b53ec03d7"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6545), "Bộ sản phẩm Mô hình giấy Anime Game Pokemon Pikachu Polygon ver 2 bao gồm:\r\n- 9 tờ kit mô hình in mực Dầu trên giấy Màu.\r\n- 4 tờ hướng dẫn lắp ráp.\r\n- Kích thước A4: Cao: 33cm x Rộng: 30cm x Sâu: 34cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-ls9lvceatuah97@resize_w450_nl.webp", "Pikachu Polygon ver 2", 59000.0, "A4", 30, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6545) },
                    { new Guid("3ab9dc02-ff80-43a3-baf2-9f110f8291c7"), new Guid("f94da136-1534-4561-8177-3c69b1fe708d"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6643), "Bộ sản phẩm Mô hình giấy Marvel Avenger Robot Iron Man Mark VII bao gồm:\r\n- 16 tờ kit mô hình.\r\n- 3 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/5fc4fc6d877bc7c905b6f92eeb951a94.webp", "Robot Iron Man Mark VII", 105000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6644) },
                    { new Guid("3f6d8d9a-7e31-4938-867d-734d9956df4b"), new Guid("66aa8768-d7e5-4663-900c-99415f7f0852"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6721), "Bộ sản phẩm Mô hình giấy kiến trúc lâu đài Đức Neuschwanstein Castle - Germany bao gồm:\r\n- 8 tờ kit mô hình.\r\n- 2 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/d50b7f9c059c8cb8e7c0654954a08ab1.webp", "Neuschwanstein Castle - Germany", 55000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6722) },
                    { new Guid("5da5b129-6f54-4422-bb02-d65fba0a0c8b"), new Guid("51c982ac-e680-4f54-a3de-b265bb164d9d"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6627), "Bộ sản phẩm Mô hình giấy máy bay Boeing 777-200 British Airways bao gồm:\r\n- 8 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/a09cfa936019a5e6c493acafbd4a13e1.webp", "Boeing 777-200 British Airways", 58000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6628) },
                    { new Guid("6e4dcf25-771a-48d9-9e6e-ab6612f9ec0f"), new Guid("51c982ac-e680-4f54-a3de-b265bb164d9d"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6581), "Bộ sản phẩm Mô hình giấy xe ô tô Lamborghini Sesto Elemento bao gồm:\r\n- 3 tờ kit mô hình.\r\n- Kích thước: Cao: 4,9cm x Rộng: 8,6cm x Sâu: 18,1cm", "https://down-vn.img.susercontent.com/file/966ca26a8de1b2f34c66449cc74e48bd.webp", "Lamborghini Sesto Elemento", 69000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6582) },
                    { new Guid("72271fd9-d772-4a82-b92e-695e2fe45bce"), new Guid("7db5876e-b1dc-484e-bafc-465b53ec03d7"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6539), "Bộ sản phẩm Mô hình giấy Anime Game Uzumaki Naruto ver 3 bao gồm:\r\n- 6 tờ kit mô hình.\r\n(Mặc định bản kit sẽ được in bản có line, nếu bạn muốn in bản ko line trong đơn hàng bạn ghi chú là \"in bản ko line\" để shop cho in nhé)\r\n- Kích thước A4: Cao: 17cm x Rộng: 20,1cm x Sâu: 28,3cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/sg-11134201-22110-igsmlbzefhkvf0.webp", "Uzumaki Naruto", 42000.0, "A4", 30, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6539) },
                    { new Guid("839450d6-ee63-48a0-8717-c8459a87cbe1"), new Guid("51c982ac-e680-4f54-a3de-b265bb164d9d"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6604), "Bộ sản phẩm Mô hình giấy xe máy Mille Miglia Custom Chopper bao gồm:\r\n- 24 tờ kit mô hình.\r\n- 8 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/2fbbe89ee72a717b7f2bed3a84d8b259.webp", "Mille Miglia Custom Chopper Bike", 149000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6605) },
                    { new Guid("85a429c3-2932-4147-866e-9c4edfb1e355"), new Guid("7db5876e-b1dc-484e-bafc-465b53ec03d7"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6567), "Bộ sản phẩm Mô hình giấy Anime Chibi Levi Ackerman ver 3 – Attack on Titan bao gồm:\r\n- 6 tờ kit mô hình.\r\n- Kích thước: Cao: 20,3cm x Rộng: 11,1cm x Sâu: 18cm", "https://down-vn.img.susercontent.com/file/a6da3b4677bd9309784051610617a5e7@resize_w450_nl.webp", "Chibi Levi Ackerman", 14000.0, "A4", 80, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6567) },
                    { new Guid("8678cc48-1bd8-4894-908c-de0526ddfe62"), new Guid("7db5876e-b1dc-484e-bafc-465b53ec03d7"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6532), "Bộ sản phẩm Mô hình giấy Anime Chibi Monkey D Luffy - One Piece bao gồm:\r\n- 18 tờ kit mô hình.\r\n- Kích thước: Cao: 40cm x Rộng: 23,4cm x Sâu: 21,6cm", "https://down-vn.img.susercontent.com/file/e82a586f3d146ea83a3b6303b4668914.webp", "Monkey D. Luffy", 55000.0, "A4", 100, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6533) },
                    { new Guid("8ce4bec0-b2b2-4a56-a51a-11b729b54b9e"), new Guid("66aa8768-d7e5-4663-900c-99415f7f0852"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6775), "Bộ sản phẩm Mô hình giấy kiến trúc Cambuchia Angkor Wat bao gồm:\r\n- 24 tờ kit mô hình.\r\n- 3 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/edb6286c7abf2d62a36a911b5d0983d4.webp", "Cambuchia Angkor Wat", 156000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6776) },
                    { new Guid("91539440-ba60-42aa-b54e-183a75ba1cc6"), new Guid("51c982ac-e680-4f54-a3de-b265bb164d9d"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6595), "Bộ sản phẩm Mô hình giấy xe ô tô Prototype Technology Group BMW bao gồm:\r\n- 6 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/9fb112bf0fe8b6b773c0aa7411a2392c.webp", "Prototype Technology Group BMW", 79000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6596) },
                    { new Guid("9826195e-1ed2-40a8-b3b6-3accd385883f"), new Guid("f94da136-1534-4561-8177-3c69b1fe708d"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6713), "Bộ sản phẩm Mô hình giấy Anime Game Chibi Doctor Strange - Marvel bao gồm:\r\n- 2 tờ kit mô hình + kèm scan code xem video hướng dẫn lắp ráp.\r\n* Xuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lzad737x2krla7@resize_w450_nl.webp", "Chibi Doctor Strange", 25000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6714) },
                    { new Guid("ae566254-1b7e-4f65-95ee-74b552d70fca"), new Guid("66aa8768-d7e5-4663-900c-99415f7f0852"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6729), "Bộ sản phẩm Mô hình giấy kiến trúc Tháp Luân Đôn Tower of London – England bao gồm:\r\n- 10 tờ kit mô hình.\r\n- 2 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/5e96e9613e2fd22d255d9d90159d19ce.webp", "Tower of London – England", 65000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6730) },
                    { new Guid("c09d5680-29de-4174-b39d-c37e722441f4"), new Guid("f94da136-1534-4561-8177-3c69b1fe708d"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6650), "Bộ sản phẩm Mô hình giấy Anime Game Chibi Thor mập - Marvel bao gồm:\r\n- 8 tờ kit mô hình in mực Dầu trên giấy Màu.\r\n- 2 tờ hướng dẫn lắp ráp.\r\n- Kích thước : Cao 15,5cm x Rộng 13cm x Sâu 9cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmua3ev8pza778.webp", "Chibi Thor ", 50000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6651) },
                    { new Guid("c3f0924c-b335-4a43-8a75-3f5d5989888d"), new Guid("f94da136-1534-4561-8177-3c69b1fe708d"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6659), "Bộ sản phẩm Mô hình giấy Anime Game Marvel Hulk Treo tường ver 3 bao gồm:\r\n– 17 tờ kit mô hình in trên giấy A4 Ford màu định lượng 180gsm (so với giấy photo là 70gsm) + scan code xem hướng dẫn.\r\n- Kích thước: Cao: khoảng 40cm", "https://down-vn.img.susercontent.com/file/8aedf29f64c9de9ac7ec2b3f48182f7b.webp", "Marvel Hulk Wall Hanging", 83000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6660) },
                    { new Guid("d9bf655a-9eff-47dc-bf07-657ac8c2fa4c"), new Guid("66aa8768-d7e5-4663-900c-99415f7f0852"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6738), "Bộ sản phẩm Mô hình giấy kiến trúc Pháp tháp Eiffel Tower bao gồm:\r\n- 9 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/a077c0d85e3866a441e4b1e76ab69dbb.webp", "Eiffel Tower", 60000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6738) },
                    { new Guid("e9185e9b-f478-4c50-ad3d-094d0805f07e"), new Guid("66aa8768-d7e5-4663-900c-99415f7f0852"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6782), "Bộ sản phẩm Mô hình giấy kiến trúc Nhà thờ chính Siena Cathedral - Italy bao gồm:\r\n- 19 tờ kit mô hình.\r\n- 4 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/e7ac1e43b3160334e9ca1fc66da7f34a.webp", "Siena Cathedral - Italy", 124000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6782) },
                    { new Guid("e9e6040f-b81e-4516-9df9-ae65745b203a"), new Guid("51c982ac-e680-4f54-a3de-b265bb164d9d"), new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6573), "Bộ sản phẩm Mô hình giấy phi thuyền không gian vũ trụ tàu con thoi Space Shuttle Atlantis bao gồm:\r\n- 11 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/4ed6a6e35f435d28286762c02db7f911.webp", "Space Shuttle Atlantis", 72000.0, "A4", 10, new DateTime(2024, 9, 28, 11, 37, 50, 909, DateTimeKind.Local).AddTicks(6574) }
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
                name: "IX_CheckOuts_OrderID",
                table: "CheckOuts",
                column: "OrderID");

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
                name: "IX_OrderProduct_ProductID",
                table: "OrderProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

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
                name: "CheckOuts");

            migrationBuilder.DropTable(
                name: "CommentsImage");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
