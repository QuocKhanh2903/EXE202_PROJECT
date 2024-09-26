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
                    { "6e2ed57d-8420-4252-a7cb-5e7a48a465c4", null, "Customer", "CUSTOMER" },
                    { "b31c08c4-2d70-4ec9-93f8-2bb667ba4d88", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0b475ddb-8a03-446d-9cfd-68bfbd295de7", 0, "9a34d3d4-0d4c-4f6d-9f97-da8f270d939e", new DateTime(2024, 9, 26, 14, 38, 34, 985, DateTimeKind.Local).AddTicks(2744), "taimodel@gmail.com", true, "Nguyễn Lương Tài", false, null, null, null, "AQAAAAIAAYagAAAAEA7algg42pj+Wi48XJoVeNUFlrRIzuW5TWZDVX83x+E+QUr92hhXoDJYZHszU3Su3Q==", "0123456789", false, "36e46570-c698-4492-912c-cf853d6d133b", false, "TaiModel" },
                    { "28cb8839-f9d3-4622-8fa4-e10c0564e648", 0, "e97b5a4b-f488-4efa-a396-c75bb57df5e7", new DateTime(2024, 9, 26, 14, 38, 35, 120, DateTimeKind.Local).AddTicks(468), "ngocha@gmail.com", true, "Ngọc Hà", false, null, null, null, "AQAAAAIAAYagAAAAEFu+xfd7kL6Yn63/UIJFu45q4AFSmvB8Bv6TXb+Gp5G9nAR+0RCdfr3RIH4/Wjnvfw==", "0123456789", false, "bf98321d-c31e-49f7-bf9b-5ee4e201f86f", false, "NgocHa" },
                    { "97b0ccc9-1db6-448d-9a15-5ec8332d1919", 0, "badcf478-92a0-4ad7-92ae-010f6d90ebf6", new DateTime(2024, 9, 26, 14, 38, 35, 60, DateTimeKind.Local).AddTicks(3557), "dinhuynhminhthu@gmail.com", true, "Đinh Huỳnh Minh Thư", false, null, null, null, "AQAAAAIAAYagAAAAENbLI2O5u0/7/vOGQrRaz9PIkrwRzvsKFdNv0kw+rxxSZbAAH3WrCQLg8DqZjbZwag==", "0123456789", false, "915031a0-902a-4a1d-b9e4-2752232f5e2e", false, "MinhThu" },
                    { "be9f9245-df6d-4839-9003-3ccd3fe06510", 0, "06053b3e-336c-419e-884d-0af5726fd07c", new DateTime(2024, 9, 26, 14, 38, 35, 238, DateTimeKind.Local).AddTicks(5995), "thuIT@gmail.com", true, "Thư AI", false, null, null, null, "AQAAAAIAAYagAAAAEKqllJQBcgxKcbMODscBX1mhu8Rl5UKiKwUvETHunntcn+yEX4wVB52dkjYNrdS8qA==", "0123456789", false, "d7bf91c5-4114-45db-b1fd-cab7efb115cb", false, "ThuIT" },
                    { "cb1d24bc-3cc9-4fe1-ac60-ab25b68ae24d", 0, "a0d112bc-c411-4e6b-9037-81eb6cefab89", new DateTime(2024, 9, 26, 14, 38, 34, 908, DateTimeKind.Local).AddTicks(6879), "bluegameming292003@gmail.com", true, "Trần Minh Quốc Khánh", false, null, null, null, "AQAAAAIAAYagAAAAELzZHzjgOu1FbebQf6Yd4w5xSeFP2RnuTUnkWQFI32zm6842oNpWutHdkdhmpq0gNw==", "0934763210", false, "6c86092c-3b9d-4fdc-84da-7d61ad937c6f", false, "Admin" },
                    { "ee6843ae-9637-45b3-94d2-257adddc2c8c", 0, "2df0a054-c9ff-4937-8387-30a34d9acb4b", new DateTime(2024, 9, 26, 14, 38, 35, 179, DateTimeKind.Local).AddTicks(3770), "nguyenvungochan@gmail.com", true, "Nguyễn Vũ Ngọc Hân", false, null, null, null, "AQAAAAIAAYagAAAAELXoeRaS6pPVOkbCcmAuDWuiQ7wmxXUEIxyff98CE0Xsi6QFkSYtUcExr9oegXay9g==", "0123456789", false, "21bae6ab-2fb8-402d-8436-fbdf7efec225", false, "NgocHan" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("0038ec84-1bf9-48dc-8764-afdc15f042d9"), "Marvel" },
                    { new Guid("2349a4b1-d8f8-46d6-b3d9-9909a2536af9"), "Anime" },
                    { new Guid("282f6ef7-00b6-4e2c-9057-9153074753aa"), "Architecture" },
                    { new Guid("2c917b6d-a5d1-4c02-a75a-f031c0caafa1"), "Vehicle" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6e2ed57d-8420-4252-a7cb-5e7a48a465c4", "0b475ddb-8a03-446d-9cfd-68bfbd295de7" },
                    { "6e2ed57d-8420-4252-a7cb-5e7a48a465c4", "28cb8839-f9d3-4622-8fa4-e10c0564e648" },
                    { "6e2ed57d-8420-4252-a7cb-5e7a48a465c4", "97b0ccc9-1db6-448d-9a15-5ec8332d1919" },
                    { "6e2ed57d-8420-4252-a7cb-5e7a48a465c4", "be9f9245-df6d-4839-9003-3ccd3fe06510" },
                    { "b31c08c4-2d70-4ec9-93f8-2bb667ba4d88", "cb1d24bc-3cc9-4fe1-ac60-ab25b68ae24d" },
                    { "6e2ed57d-8420-4252-a7cb-5e7a48a465c4", "ee6843ae-9637-45b3-94d2-257adddc2c8c" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "CreatedAt", "Description", "ImgUrl", "Name", "Price", "PrintPaperType", "ProductQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("08f8291b-80f0-4353-b1d5-827e525181b7"), new Guid("2c917b6d-a5d1-4c02-a75a-f031c0caafa1"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(644), "Bộ sản phẩm Mô hình giấy xe ô tô Prototype Technology Group BMW bao gồm:\r\n- 6 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/9fb112bf0fe8b6b773c0aa7411a2392c.webp", "Prototype Technology Group BMW", 79.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(644) },
                    { new Guid("10c6c363-778f-4616-8e4f-600abafca9e1"), new Guid("2349a4b1-d8f8-46d6-b3d9-9909a2536af9"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(604), "Bộ sản phẩm Mô hình giấy Anime Chibi Levi Ackerman ver 3 – Attack on Titan bao gồm:\r\n- 6 tờ kit mô hình.\r\n- Kích thước: Cao: 20,3cm x Rộng: 11,1cm x Sâu: 18cm", "https://down-vn.img.susercontent.com/file/a6da3b4677bd9309784051610617a5e7@resize_w450_nl.webp", "Chibi Levi Ackerman", 14.0, "A4", 80, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(604) },
                    { new Guid("11dd093c-e0b0-462f-ae8c-afc0125f0798"), new Guid("0038ec84-1bf9-48dc-8764-afdc15f042d9"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(830), "Bộ sản phẩm Mô hình giấy Marvel Avengers Iron Spider bao gồm:\r\n- 15 tờ kit mô hình.\r\n- Kích thước: Cao: 38cm x Rộng: 30,7cm x Sâu: 34,5cm", "https://down-vn.img.susercontent.com/file/4b925257b8c606d8ba5549860b146ad1.webp", "Marvel Avengers Iron Spider", 100.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(831) },
                    { new Guid("159509ae-b361-4380-bb72-83fe4523d147"), new Guid("282f6ef7-00b6-4e2c-9057-9153074753aa"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(861), "Bộ sản phẩm Mô hình giấy kiến trúc Tháp Luân Đôn Tower of London – England bao gồm:\r\n- 10 tờ kit mô hình.\r\n- 2 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/5e96e9613e2fd22d255d9d90159d19ce.webp", "Tower of London – England", 65.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(861) },
                    { new Guid("24326075-ca90-489a-aa9c-37d0ca17639d"), new Guid("282f6ef7-00b6-4e2c-9057-9153074753aa"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(888), "Bộ sản phẩm Mô hình giấy kiến trúc Nhà thờ chính Siena Cathedral - Italy bao gồm:\r\n- 19 tờ kit mô hình.\r\n- 4 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/e7ac1e43b3160334e9ca1fc66da7f34a.webp", "Siena Cathedral - Italy", 124.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(888) },
                    { new Guid("24e4abbf-d9d4-4316-ae7f-acd67adae1c6"), new Guid("2c917b6d-a5d1-4c02-a75a-f031c0caafa1"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(779), "Bộ sản phẩm Mô hình giấy máy bay Boeing 777-200 British Airways bao gồm:\r\n- 8 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/a09cfa936019a5e6c493acafbd4a13e1.webp", "Boeing 777-200 British Airways", 58.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(780) },
                    { new Guid("3894302e-2637-4bf8-9c95-c0f132140c4d"), new Guid("282f6ef7-00b6-4e2c-9057-9153074753aa"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(872), "Bộ sản phẩm Mô hình giấy kiến trúc Pháp tháp Eiffel Tower bao gồm:\r\n- 9 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/a077c0d85e3866a441e4b1e76ab69dbb.webp", "Eiffel Tower", 60.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(873) },
                    { new Guid("41cd6067-3fd4-4c39-b20a-cb02b9fb8e2b"), new Guid("0038ec84-1bf9-48dc-8764-afdc15f042d9"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(800), "Bộ sản phẩm Mô hình giấy Anime Game Marvel Hulk Treo tường ver 3 bao gồm:\r\n– 17 tờ kit mô hình in trên giấy A4 Ford màu định lượng 180gsm (so với giấy photo là 70gsm) + scan code xem hướng dẫn.\r\n- Kích thước: Cao: khoảng 40cm", "https://down-vn.img.susercontent.com/file/8aedf29f64c9de9ac7ec2b3f48182f7b.webp", "Marvel Hulk Wall Hanging", 83.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(809) },
                    { new Guid("4b8f50ec-beb4-41d1-835f-ce9035bb450c"), new Guid("282f6ef7-00b6-4e2c-9057-9153074753aa"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(853), "Bộ sản phẩm Mô hình giấy kiến trúc lâu đài Đức Neuschwanstein Castle - Germany bao gồm:\r\n- 8 tờ kit mô hình.\r\n- 2 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/d50b7f9c059c8cb8e7c0654954a08ab1.webp", "Neuschwanstein Castle - Germany", 55.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(854) },
                    { new Guid("4c1c8aa2-2b8b-4f2c-9438-3458146ab7c1"), new Guid("0038ec84-1bf9-48dc-8764-afdc15f042d9"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(786), "Bộ sản phẩm Mô hình giấy Marvel Avenger Robot Iron Man Mark VII bao gồm:\r\n- 16 tờ kit mô hình.\r\n- 3 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/5fc4fc6d877bc7c905b6f92eeb951a94.webp", "Robot Iron Man Mark VII", 105.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(787) },
                    { new Guid("8e38ee19-95d8-4452-b525-bfd7cb754f58"), new Guid("2349a4b1-d8f8-46d6-b3d9-9909a2536af9"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(587), "Bộ sản phẩm Mô hình giấy Anime Chibi Monkey D Luffy - One Piece bao gồm:\r\n- 18 tờ kit mô hình.\r\n- Kích thước: Cao: 40cm x Rộng: 23,4cm x Sâu: 21,6cm", "https://down-vn.img.susercontent.com/file/e82a586f3d146ea83a3b6303b4668914.webp", "Monkey D. Luffy", 55.0, "A4", 100, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(587) },
                    { new Guid("90804a77-dc04-477b-933e-c5796af1d707"), new Guid("0038ec84-1bf9-48dc-8764-afdc15f042d9"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(843), "Bộ sản phẩm Mô hình giấy Anime Game Chibi Doctor Strange - Marvel bao gồm:\r\n- 2 tờ kit mô hình + kèm scan code xem video hướng dẫn lắp ráp.\r\n* Xuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lzad737x2krla7@resize_w450_nl.webp", "Chibi Doctor Strange", 25.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(844) },
                    { new Guid("a4d07c2b-34b3-4766-8063-6eeb9acdac0c"), new Guid("2349a4b1-d8f8-46d6-b3d9-9909a2536af9"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(598), "Bộ sản phẩm Mô hình giấy Anime Game Pokemon Pikachu Polygon ver 2 bao gồm:\r\n- 9 tờ kit mô hình in mực Dầu trên giấy Màu.\r\n- 4 tờ hướng dẫn lắp ráp.\r\n- Kích thước A4: Cao: 33cm x Rộng: 30cm x Sâu: 34cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-ls9lvceatuah97@resize_w450_nl.webp", "Pikachu Polygon ver 2", 59.0, "A4", 30, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(599) },
                    { new Guid("adcea5de-6922-4e4b-8096-fa188056b11b"), new Guid("2c917b6d-a5d1-4c02-a75a-f031c0caafa1"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(650), "Bộ sản phẩm Mô hình giấy xe máy Mille Miglia Custom Chopper bao gồm:\r\n- 24 tờ kit mô hình.\r\n- 8 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/2fbbe89ee72a717b7f2bed3a84d8b259.webp", "Mille Miglia Custom Chopper Bike", 149.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(651) },
                    { new Guid("aff264ce-9c0d-4c6b-b650-f88fd71a6c2f"), new Guid("2c917b6d-a5d1-4c02-a75a-f031c0caafa1"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(612), "Bộ sản phẩm Mô hình giấy phi thuyền không gian vũ trụ tàu con thoi Space Shuttle Atlantis bao gồm:\r\n- 11 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/4ed6a6e35f435d28286762c02db7f911.webp", "Space Shuttle Atlantis", 72.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(613) },
                    { new Guid("c656f16e-3218-4cc3-a5b9-9ee640893cec"), new Guid("0038ec84-1bf9-48dc-8764-afdc15f042d9"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(794), "Bộ sản phẩm Mô hình giấy Anime Game Chibi Thor mập - Marvel bao gồm:\r\n- 8 tờ kit mô hình in mực Dầu trên giấy Màu.\r\n- 2 tờ hướng dẫn lắp ráp.\r\n- Kích thước : Cao 15,5cm x Rộng 13cm x Sâu 9cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmua3ev8pza778.webp", "Chibi Thor ", 50.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(794) },
                    { new Guid("ccec5d5e-9ffc-4413-9d66-43faf953fa79"), new Guid("2349a4b1-d8f8-46d6-b3d9-9909a2536af9"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(592), "Bộ sản phẩm Mô hình giấy Anime Game Uzumaki Naruto ver 3 bao gồm:\r\n- 6 tờ kit mô hình.\r\n(Mặc định bản kit sẽ được in bản có line, nếu bạn muốn in bản ko line trong đơn hàng bạn ghi chú là \"in bản ko line\" để shop cho in nhé)\r\n- Kích thước A4: Cao: 17cm x Rộng: 20,1cm x Sâu: 28,3cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/sg-11134201-22110-igsmlbzefhkvf0.webp", "Uzumaki Naruto", 42.0, "A4", 30, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(593) },
                    { new Guid("d1c01c4e-179e-4aa5-9712-7aa3e9980d88"), new Guid("2349a4b1-d8f8-46d6-b3d9-9909a2536af9"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(570), "Bộ sản phẩm Mô hình giấy Anime Goku SSJ HD – Dragon Ball bao gồm:\r\n- 25 tờ kit mô hình.\r\n- Kích thước: Cao: 55,5cm x Rộng: 13,4cm x Sâu: 23,9cm", "https://down-vn.img.susercontent.com/file/ea93877ccd8d3700b6b9ede4220df541.webp", "Son Goku", 50.0, "A4", 50, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(574) },
                    { new Guid("d2806663-9871-427e-8c39-4c12b00ef90f"), new Guid("2c917b6d-a5d1-4c02-a75a-f031c0caafa1"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(622), "Bộ sản phẩm Mô hình giấy xe ô tô Lamborghini Sesto Elemento bao gồm:\r\n- 3 tờ kit mô hình.\r\n- Kích thước: Cao: 4,9cm x Rộng: 8,6cm x Sâu: 18,1cm", "https://down-vn.img.susercontent.com/file/966ca26a8de1b2f34c66449cc74e48bd.webp", "Lamborghini Sesto Elemento", 69.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(623) },
                    { new Guid("e920a968-d094-4ebc-9d0f-cdb2bb4ae04d"), new Guid("282f6ef7-00b6-4e2c-9057-9153074753aa"), new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(879), "Bộ sản phẩm Mô hình giấy kiến trúc Cambuchia Angkor Wat bao gồm:\r\n- 24 tờ kit mô hình.\r\n- 3 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/edb6286c7abf2d62a36a911b5d0983d4.webp", "Cambuchia Angkor Wat", 156.0, "A4", 10, new DateTime(2024, 9, 26, 14, 38, 35, 298, DateTimeKind.Local).AddTicks(880) }
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
