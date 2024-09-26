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
                    { "7daea6a4-5d35-4cb2-907c-29eb1793e201", null, "Customer", "CUSTOMER" },
                    { "fc8c6e5b-f4e8-472b-b6ba-09a5dceb3c93", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "354a25bf-3714-4e40-8025-00d9dd12db65", 0, "ab99e713-a7fd-49bf-9f89-76fa9d86529a", new DateTime(2024, 9, 26, 15, 2, 39, 140, DateTimeKind.Local).AddTicks(4630), "ngocha@gmail.com", true, "Ngọc Hà", false, null, null, null, "AQAAAAIAAYagAAAAEOthCq8W215dkkkkRIih37QN11JMQS6sG7yOp7HwnAKRZLIFieZH5uBJoHvDcdaJoA==", "0123456789", false, "1d11413f-7c2c-48b9-9981-416a15d57695", false, "NgocHa" },
                    { "3a0fa642-476e-40ae-8add-87d502a4e4d5", 0, "97a7c332-729b-4935-8432-0c7fb2154d15", new DateTime(2024, 9, 26, 15, 2, 39, 80, DateTimeKind.Local).AddTicks(6132), "dinhuynhminhthu@gmail.com", true, "Đinh Huỳnh Minh Thư", false, null, null, null, "AQAAAAIAAYagAAAAENPvikVyqbH5HRkkO0revG++T5hZ8FTJyGKS7BDy2RDuLIxmAT0ItfdYitF0o45RQA==", "0123456789", false, "3faed014-2d19-4735-9453-21ded65f8072", false, "MinhThu" },
                    { "a591095b-50cc-4860-b0b2-e758d6165500", 0, "b0e8aa60-6d3e-4a36-b723-9537024ebada", new DateTime(2024, 9, 26, 15, 2, 39, 214, DateTimeKind.Local).AddTicks(2749), "nguyenvungochan@gmail.com", true, "Nguyễn Vũ Ngọc Hân", false, null, null, null, "AQAAAAIAAYagAAAAEGE7qaJwYHuilasL0kKLn6db2oHoVFzurbUTceW599PfDXN3wveyapKQdd6UN53gfA==", "0123456789", false, "2ed35d08-c754-4ab4-a928-5a6a034a1624", false, "NgocHan" },
                    { "c779ffa8-c675-42c6-a067-f13c70579722", 0, "36a1db4f-4e00-4602-9954-c5467b038a0c", new DateTime(2024, 9, 26, 15, 2, 39, 273, DateTimeKind.Local).AddTicks(2741), "thuIT@gmail.com", true, "Thư AI", false, null, null, null, "AQAAAAIAAYagAAAAEAkjB11gBKQmztiptrvEi9E1cv33ecGJ2JDPK5ivnVOj/m2KHPEVLTyeKawfgPLyfg==", "0123456789", false, "ff77649f-c947-4435-bb2f-dcb79fdc555e", false, "ThuIT" },
                    { "e97182cc-ec3c-429c-beb6-5b6534edab28", 0, "051337cf-dd3d-4890-9667-5815cf330121", new DateTime(2024, 9, 26, 15, 2, 38, 960, DateTimeKind.Local).AddTicks(6280), "bluegameming292003@gmail.com", true, "Trần Minh Quốc Khánh", false, null, null, null, "AQAAAAIAAYagAAAAEHt7JYXIZ7imnIivpQRmCwLr8D2pm+nXOjDr3wqXpW0MIwfQbcigi5g7wM2osNA2UA==", "0934763210", false, "38447e3f-f0b8-4d52-a2db-cdbb5bb02276", false, "Admin" },
                    { "fe7995af-a50f-4fb9-bb7e-440b4490b570", 0, "f0626891-4c61-4e75-9f5e-122a33aa9858", new DateTime(2024, 9, 26, 15, 2, 39, 20, DateTimeKind.Local).AddTicks(9332), "taimodel@gmail.com", true, "Nguyễn Lương Tài", false, null, null, null, "AQAAAAIAAYagAAAAEDCi/t/hW6OfRz67ztZytFMV5/bLNOlt4Ts63pX+JrL78+XeUwoYYek9nFsLEJTgtw==", "0123456789", false, "e26ec9b0-6d42-46ec-9b8e-f5d18fb25d15", false, "TaiModel" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("39eca832-21d4-465b-a87c-2678b3a1f447"), "Vehicle" },
                    { new Guid("833ca1d8-d6f5-4209-af98-ee0225f4752b"), "Architecture" },
                    { new Guid("d429237b-cc96-4a06-bfc2-bb1c29dde115"), "Marvel" },
                    { new Guid("fc7e1651-a9db-4cdd-96be-7f5e89d0d51a"), "Anime" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7daea6a4-5d35-4cb2-907c-29eb1793e201", "354a25bf-3714-4e40-8025-00d9dd12db65" },
                    { "7daea6a4-5d35-4cb2-907c-29eb1793e201", "3a0fa642-476e-40ae-8add-87d502a4e4d5" },
                    { "7daea6a4-5d35-4cb2-907c-29eb1793e201", "a591095b-50cc-4860-b0b2-e758d6165500" },
                    { "7daea6a4-5d35-4cb2-907c-29eb1793e201", "c779ffa8-c675-42c6-a067-f13c70579722" },
                    { "fc8c6e5b-f4e8-472b-b6ba-09a5dceb3c93", "e97182cc-ec3c-429c-beb6-5b6534edab28" },
                    { "7daea6a4-5d35-4cb2-907c-29eb1793e201", "fe7995af-a50f-4fb9-bb7e-440b4490b570" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "CreatedAt", "Description", "ImgUrl", "Name", "Price", "PrintPaperType", "ProductQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("054c85ff-85d0-440c-936d-6b17da77ae3c"), new Guid("fc7e1651-a9db-4cdd-96be-7f5e89d0d51a"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1041), "Bộ sản phẩm Mô hình giấy Anime Game Pokemon Pikachu Polygon ver 2 bao gồm:\r\n- 9 tờ kit mô hình in mực Dầu trên giấy Màu.\r\n- 4 tờ hướng dẫn lắp ráp.\r\n- Kích thước A4: Cao: 33cm x Rộng: 30cm x Sâu: 34cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-ls9lvceatuah97@resize_w450_nl.webp", "Pikachu Polygon ver 2", 59000.0, "A4", 30, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1042) },
                    { new Guid("0609fd32-3eb0-4dda-943c-6337bcebd5fb"), new Guid("fc7e1651-a9db-4cdd-96be-7f5e89d0d51a"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(901), "Bộ sản phẩm Mô hình giấy Anime Game Uzumaki Naruto ver 3 bao gồm:\r\n- 6 tờ kit mô hình.\r\n(Mặc định bản kit sẽ được in bản có line, nếu bạn muốn in bản ko line trong đơn hàng bạn ghi chú là \"in bản ko line\" để shop cho in nhé)\r\n- Kích thước A4: Cao: 17cm x Rộng: 20,1cm x Sâu: 28,3cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/sg-11134201-22110-igsmlbzefhkvf0.webp", "Uzumaki Naruto", 42000.0, "A4", 30, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(902) },
                    { new Guid("062c24b1-b57b-45b7-89fd-51b0e06345ad"), new Guid("833ca1d8-d6f5-4209-af98-ee0225f4752b"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1191), "Bộ sản phẩm Mô hình giấy kiến trúc Cambuchia Angkor Wat bao gồm:\r\n- 24 tờ kit mô hình.\r\n- 3 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/edb6286c7abf2d62a36a911b5d0983d4.webp", "Cambuchia Angkor Wat", 156000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1192) },
                    { new Guid("0e19a79b-a316-495a-b867-9a1185192a79"), new Guid("39eca832-21d4-465b-a87c-2678b3a1f447"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1056), "Bộ sản phẩm Mô hình giấy phi thuyền không gian vũ trụ tàu con thoi Space Shuttle Atlantis bao gồm:\r\n- 11 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/4ed6a6e35f435d28286762c02db7f911.webp", "Space Shuttle Atlantis", 72000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1057) },
                    { new Guid("2851db28-15cf-47ef-b6d2-25f2d27850a0"), new Guid("833ca1d8-d6f5-4209-af98-ee0225f4752b"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1174), "Bộ sản phẩm Mô hình giấy kiến trúc Tháp Luân Đôn Tower of London – England bao gồm:\r\n- 10 tờ kit mô hình.\r\n- 2 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/5e96e9613e2fd22d255d9d90159d19ce.webp", "Tower of London – England", 65000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1174) },
                    { new Guid("2f9dbde4-4c83-4966-b572-3a99a2479c92"), new Guid("d429237b-cc96-4a06-bfc2-bb1c29dde115"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1113), "Bộ sản phẩm Mô hình giấy Anime Game Chibi Thor mập - Marvel bao gồm:\r\n- 8 tờ kit mô hình in mực Dầu trên giấy Màu.\r\n- 2 tờ hướng dẫn lắp ráp.\r\n- Kích thước : Cao 15,5cm x Rộng 13cm x Sâu 9cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmua3ev8pza778.webp", "Chibi Thor ", 50000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1114) },
                    { new Guid("30376a83-1042-4bfb-b3be-569e2b09b728"), new Guid("d429237b-cc96-4a06-bfc2-bb1c29dde115"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1156), "Bộ sản phẩm Mô hình giấy Anime Game Chibi Doctor Strange - Marvel bao gồm:\r\n- 2 tờ kit mô hình + kèm scan code xem video hướng dẫn lắp ráp.\r\n* Xuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lzad737x2krla7@resize_w450_nl.webp", "Chibi Doctor Strange", 25000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1157) },
                    { new Guid("3b3baa5b-782e-42b8-8804-40ad37451310"), new Guid("d429237b-cc96-4a06-bfc2-bb1c29dde115"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1132), "Bộ sản phẩm Mô hình giấy Marvel Avengers Iron Spider bao gồm:\r\n- 15 tờ kit mô hình.\r\n- Kích thước: Cao: 38cm x Rộng: 30,7cm x Sâu: 34,5cm", "https://down-vn.img.susercontent.com/file/4b925257b8c606d8ba5549860b146ad1.webp", "Marvel Avengers Iron Spider", 100000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1144) },
                    { new Guid("5bcd5ff1-b159-489c-b761-b81618863cd0"), new Guid("fc7e1651-a9db-4cdd-96be-7f5e89d0d51a"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(863), "Bộ sản phẩm Mô hình giấy Anime Goku SSJ HD – Dragon Ball bao gồm:\r\n- 25 tờ kit mô hình.\r\n- Kích thước: Cao: 55,5cm x Rộng: 13,4cm x Sâu: 23,9cm", "https://down-vn.img.susercontent.com/file/ea93877ccd8d3700b6b9ede4220df541.webp", "Son Goku", 50000.0, "A4", 50, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(866) },
                    { new Guid("6253f14f-94ce-49a7-86aa-bbf3068c4805"), new Guid("d429237b-cc96-4a06-bfc2-bb1c29dde115"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1120), "Bộ sản phẩm Mô hình giấy Anime Game Marvel Hulk Treo tường ver 3 bao gồm:\r\n– 17 tờ kit mô hình in trên giấy A4 Ford màu định lượng 180gsm (so với giấy photo là 70gsm) + scan code xem hướng dẫn.\r\n- Kích thước: Cao: khoảng 40cm", "https://down-vn.img.susercontent.com/file/8aedf29f64c9de9ac7ec2b3f48182f7b.webp", "Marvel Hulk Wall Hanging", 83000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1121) },
                    { new Guid("63d71614-0b4e-476b-92e4-c5acbb736891"), new Guid("39eca832-21d4-465b-a87c-2678b3a1f447"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1074), "Bộ sản phẩm Mô hình giấy xe máy Mille Miglia Custom Chopper bao gồm:\r\n- 24 tờ kit mô hình.\r\n- 8 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/2fbbe89ee72a717b7f2bed3a84d8b259.webp", "Mille Miglia Custom Chopper Bike", 149000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1075) },
                    { new Guid("7a51e04a-e6f4-4856-98ad-600dfe6f6ad6"), new Guid("833ca1d8-d6f5-4209-af98-ee0225f4752b"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1164), "Bộ sản phẩm Mô hình giấy kiến trúc lâu đài Đức Neuschwanstein Castle - Germany bao gồm:\r\n- 8 tờ kit mô hình.\r\n- 2 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/d50b7f9c059c8cb8e7c0654954a08ab1.webp", "Neuschwanstein Castle - Germany", 55000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1165) },
                    { new Guid("7e4e9930-0826-42cf-84fe-8fed33c07380"), new Guid("39eca832-21d4-465b-a87c-2678b3a1f447"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1069), "Bộ sản phẩm Mô hình giấy xe ô tô Prototype Technology Group BMW bao gồm:\r\n- 6 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/9fb112bf0fe8b6b773c0aa7411a2392c.webp", "Prototype Technology Group BMW", 79000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1069) },
                    { new Guid("966563f1-9a83-4de8-9263-02a9a39758ff"), new Guid("833ca1d8-d6f5-4209-af98-ee0225f4752b"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1197), "Bộ sản phẩm Mô hình giấy kiến trúc Nhà thờ chính Siena Cathedral - Italy bao gồm:\r\n- 19 tờ kit mô hình.\r\n- 4 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/e7ac1e43b3160334e9ca1fc66da7f34a.webp", "Siena Cathedral - Italy", 124000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1198) },
                    { new Guid("acd28c38-eda4-481b-ad84-bbd071349c09"), new Guid("833ca1d8-d6f5-4209-af98-ee0225f4752b"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1182), "Bộ sản phẩm Mô hình giấy kiến trúc Pháp tháp Eiffel Tower bao gồm:\r\n- 9 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/a077c0d85e3866a441e4b1e76ab69dbb.webp", "Eiffel Tower", 60000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1183) },
                    { new Guid("d1a6c9e8-207b-4c58-bcee-ff2b938db4d1"), new Guid("fc7e1651-a9db-4cdd-96be-7f5e89d0d51a"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1047), "Bộ sản phẩm Mô hình giấy Anime Chibi Levi Ackerman ver 3 – Attack on Titan bao gồm:\r\n- 6 tờ kit mô hình.\r\n- Kích thước: Cao: 20,3cm x Rộng: 11,1cm x Sâu: 18cm", "https://down-vn.img.susercontent.com/file/a6da3b4677bd9309784051610617a5e7@resize_w450_nl.webp", "Chibi Levi Ackerman", 14000.0, "A4", 80, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1048) },
                    { new Guid("d443ed0e-93cd-4a96-b683-92f052e044e5"), new Guid("39eca832-21d4-465b-a87c-2678b3a1f447"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1092), "Bộ sản phẩm Mô hình giấy máy bay Boeing 777-200 British Airways bao gồm:\r\n- 8 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/a09cfa936019a5e6c493acafbd4a13e1.webp", "Boeing 777-200 British Airways", 58000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1093) },
                    { new Guid("da4c58d8-966a-4db6-9ebb-2b9c5a76f1a9"), new Guid("d429237b-cc96-4a06-bfc2-bb1c29dde115"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1105), "Bộ sản phẩm Mô hình giấy Marvel Avenger Robot Iron Man Mark VII bao gồm:\r\n- 16 tờ kit mô hình.\r\n- 3 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/5fc4fc6d877bc7c905b6f92eeb951a94.webp", "Robot Iron Man Mark VII", 105000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1106) },
                    { new Guid("e31cd274-6e8b-4dee-ae26-d950231be745"), new Guid("39eca832-21d4-465b-a87c-2678b3a1f447"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1063), "Bộ sản phẩm Mô hình giấy xe ô tô Lamborghini Sesto Elemento bao gồm:\r\n- 3 tờ kit mô hình.\r\n- Kích thước: Cao: 4,9cm x Rộng: 8,6cm x Sâu: 18,1cm", "https://down-vn.img.susercontent.com/file/966ca26a8de1b2f34c66449cc74e48bd.webp", "Lamborghini Sesto Elemento", 69000.0, "A4", 10, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(1063) },
                    { new Guid("e32048f0-9cdd-4c2a-8c91-08705a541c88"), new Guid("fc7e1651-a9db-4cdd-96be-7f5e89d0d51a"), new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(884), "Bộ sản phẩm Mô hình giấy Anime Chibi Monkey D Luffy - One Piece bao gồm:\r\n- 18 tờ kit mô hình.\r\n- Kích thước: Cao: 40cm x Rộng: 23,4cm x Sâu: 21,6cm", "https://down-vn.img.susercontent.com/file/e82a586f3d146ea83a3b6303b4668914.webp", "Monkey D. Luffy", 55000.0, "A4", 100, new DateTime(2024, 9, 26, 15, 2, 39, 333, DateTimeKind.Local).AddTicks(885) }
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
