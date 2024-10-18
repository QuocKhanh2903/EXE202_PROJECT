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
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
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
                    { "3189ea3c-31ef-41be-a305-e6277a05ab69", null, "Admin", "ADMIN" },
                    { "accd48e1-e74e-4aca-b570-bf64312a83b1", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "CreatedAt", "District", "Email", "EmailConfirmed", "FullName", "HouseAddress", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Ward" },
                values: new object[,]
                {
                    { "062822b0-80af-4bc9-a491-91cb1a4e778e", 0, null, "e3bd9422-0600-41e4-a293-84e8cfe20388", new DateTime(2024, 10, 16, 15, 14, 35, 541, DateTimeKind.Local).AddTicks(4741), null, "ngocha@gmail.com", true, "Ngọc Hà", null, false, null, null, null, "AQAAAAIAAYagAAAAEALi7cRZCZhC9ljpVn/ooW7C88SPC1vJgyIgw0kxM7Eg75obdHRJTgTIJdehXLBugg==", "0123456789", false, "1542b5e8-8d6b-4251-974d-5b8c4ebf6788", false, "NgocHa", null },
                    { "0da17ed7-ffb0-491a-9284-c6bae0587dac", 0, null, "d6657377-0805-453a-9e41-3a4dd8681807", new DateTime(2024, 10, 16, 15, 14, 35, 481, DateTimeKind.Local).AddTicks(5932), null, "dinhuynhminhthu@gmail.com", true, "Đinh Huỳnh Minh Thư", null, false, null, null, null, "AQAAAAIAAYagAAAAEAtqmm4BvcJwkwHChUnDQmPGH2WCiB9O6RwDOJkOhsweyErTzLiMKJNbVFeQy3thiA==", "0123456789", false, "be1cb96e-fb6d-49cf-adeb-1668eb13c43d", false, "MinhThu", null },
                    { "1fd3f013-1d2b-4941-9016-60dc84b8ade3", 0, null, "2308871c-b36e-4f0b-9ba9-c8b3725dc993", new DateTime(2024, 10, 16, 15, 14, 35, 666, DateTimeKind.Local).AddTicks(4391), null, "thuIT@gmail.com", true, "Thư AI", null, false, null, null, null, "AQAAAAIAAYagAAAAEDFV0zMjTeBltY0Med6fW21iwGkOuxJM5y7XTeRhyYFlsRvskj0JitYEjzoh/Znpag==", "0123456789", false, "33b30380-8ba0-40d7-8aa8-ce507acba316", false, "ThuIT", null },
                    { "59ede842-cf12-4e47-a4ad-83b069c0d704", 0, null, "abf4e61e-91b4-49e2-b739-586b61fd1053", new DateTime(2024, 10, 16, 15, 14, 35, 601, DateTimeKind.Local).AddTicks(2918), null, "nguyenvungochan@gmail.com", true, "Nguyễn Vũ Ngọc Hân", null, false, null, null, null, "AQAAAAIAAYagAAAAEBnt53U4jJ/IdwtZV9jNY2A4sl5F+SqnI1e1WHr3M21DU6oV757kbxL92yS2pq/hbQ==", "0123456789", false, "71a5f9c0-1986-4cb7-a787-fdcb9087a94d", false, "NgocHan", null },
                    { "99cce0f7-0a0a-4fdb-89ce-3f130d9cee88", 0, null, "bad2b764-268d-4bc8-8382-5b69cb8fed2a", new DateTime(2024, 10, 16, 15, 14, 35, 420, DateTimeKind.Local).AddTicks(7219), null, "taimodel@gmail.com", true, "Nguyễn Lương Tài", null, false, null, null, null, "AQAAAAIAAYagAAAAEFRApQu7vpeilqE+scv9OJBMgF4SDCVWm1kyecm2GGt8UE4O66zC+JczP3S8ba+sig==", "0123456789", false, "81af7dfe-7d41-4420-a484-d91f0e80dadd", false, "TaiModel", null },
                    { "a89c25d6-cce0-4254-9a16-5663d79746cd", 0, null, "b50f1bf3-17ac-42ec-99ac-c853abe22832", new DateTime(2024, 10, 16, 15, 14, 35, 361, DateTimeKind.Local).AddTicks(6890), null, "bluegameming292003@gmail.com", true, "Trần Minh Quốc Khánh", null, false, null, null, null, "AQAAAAIAAYagAAAAEBzMMRBTsWJe+/easo8TpnAYDXVMWz/XCIERKm24/7Ld7Cga4C3vZp/B1FEm8mWAjQ==", "0934763210", false, "3e49f2da-4834-40cf-9771-22cfbad5dca7", false, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("1d3e2aea-8bff-43a3-b72e-1a5c0ad3e905"), "Anime" },
                    { new Guid("a3ade310-8d30-4aef-9bc8-f69823ec48a1"), "Marvel" },
                    { new Guid("a8c2a7b0-f586-42d1-bf49-11e02693b639"), "Architecture" },
                    { new Guid("e6224088-98c3-452c-bd88-c004eec31463"), "Vehicle" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "accd48e1-e74e-4aca-b570-bf64312a83b1", "062822b0-80af-4bc9-a491-91cb1a4e778e" },
                    { "accd48e1-e74e-4aca-b570-bf64312a83b1", "0da17ed7-ffb0-491a-9284-c6bae0587dac" },
                    { "accd48e1-e74e-4aca-b570-bf64312a83b1", "1fd3f013-1d2b-4941-9016-60dc84b8ade3" },
                    { "accd48e1-e74e-4aca-b570-bf64312a83b1", "59ede842-cf12-4e47-a4ad-83b069c0d704" },
                    { "accd48e1-e74e-4aca-b570-bf64312a83b1", "99cce0f7-0a0a-4fdb-89ce-3f130d9cee88" },
                    { "3189ea3c-31ef-41be-a305-e6277a05ab69", "a89c25d6-cce0-4254-9a16-5663d79746cd" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartID", "UserID" },
                values: new object[,]
                {
                    { new Guid("0175d658-c44d-4ee6-ae73-c9683daa3698"), "a89c25d6-cce0-4254-9a16-5663d79746cd" },
                    { new Guid("177840a5-eca3-42d4-90d0-3ccdf7e94d32"), "0da17ed7-ffb0-491a-9284-c6bae0587dac" },
                    { new Guid("7cad853c-87ff-4408-9821-0ab7d5395b00"), "1fd3f013-1d2b-4941-9016-60dc84b8ade3" },
                    { new Guid("a1141166-0572-4f67-bf44-26a9db156e5d"), "99cce0f7-0a0a-4fdb-89ce-3f130d9cee88" },
                    { new Guid("b3af7fa3-cd44-44e9-9b1f-b914dc827a46"), "062822b0-80af-4bc9-a491-91cb1a4e778e" },
                    { new Guid("d9d7b0a3-ad22-44bf-baa0-8105c791c1b8"), "59ede842-cf12-4e47-a4ad-83b069c0d704" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "CreatedAt", "Description", "ImgUrl", "Name", "Price", "PrintPaperType", "ProductQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00b2ccdb-f703-4020-a5ce-8b0654ac70c6"), new Guid("e6224088-98c3-452c-bd88-c004eec31463"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4962), "Bộ sản phẩm Mô hình giấy xe ô tô Prototype Technology Group BMW bao gồm:\r\n- 6 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/9fb112bf0fe8b6b773c0aa7411a2392c.webp", "Prototype Technology Group BMW", 79000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4962) },
                    { new Guid("07c76a33-7e8d-4317-ab6f-5dd2a8fdc699"), new Guid("1d3e2aea-8bff-43a3-b72e-1a5c0ad3e905"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4909), "Bộ sản phẩm Mô hình giấy Anime Game Uzumaki Naruto ver 3 bao gồm:\r\n- 6 tờ kit mô hình.\r\n(Mặc định bản kit sẽ được in bản có line, nếu bạn muốn in bản ko line trong đơn hàng bạn ghi chú là \"in bản ko line\" để shop cho in nhé)\r\n- Kích thước A4: Cao: 17cm x Rộng: 20,1cm x Sâu: 28,3cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/sg-11134201-22110-igsmlbzefhkvf0.webp", "Uzumaki Naruto", 42000.0, "A4", 30, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4909) },
                    { new Guid("135c9a74-91c2-4ead-9bb3-489024f13050"), new Guid("e6224088-98c3-452c-bd88-c004eec31463"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4967), "Bộ sản phẩm Mô hình giấy xe máy Mille Miglia Custom Chopper bao gồm:\r\n- 24 tờ kit mô hình.\r\n- 8 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/2fbbe89ee72a717b7f2bed3a84d8b259.webp", "Mille Miglia Custom Chopper Bike", 149000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4968) },
                    { new Guid("1710dc28-3595-4082-a879-3562e06daa6d"), new Guid("a3ade310-8d30-4aef-9bc8-f69823ec48a1"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5008), "Bộ sản phẩm Mô hình giấy Anime Game Marvel Hulk Treo tường ver 3 bao gồm:\r\n– 17 tờ kit mô hình in trên giấy A4 Ford màu định lượng 180gsm (so với giấy photo là 70gsm) + scan code xem hướng dẫn.\r\n- Kích thước: Cao: khoảng 40cm", "https://down-vn.img.susercontent.com/file/8aedf29f64c9de9ac7ec2b3f48182f7b.webp", "Marvel Hulk Wall Hanging", 83000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5008) },
                    { new Guid("1f866ce8-b5ec-4f57-a3dc-c0ba6e398b8a"), new Guid("a8c2a7b0-f586-42d1-bf49-11e02693b639"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5190), "Bộ sản phẩm Mô hình giấy kiến trúc Nhà thờ chính Siena Cathedral - Italy bao gồm:\r\n- 19 tờ kit mô hình.\r\n- 4 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/e7ac1e43b3160334e9ca1fc66da7f34a.webp", "Siena Cathedral - Italy", 124000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5191) },
                    { new Guid("3657b0dd-1994-4c86-8c2e-2366ae627f83"), new Guid("a8c2a7b0-f586-42d1-bf49-11e02693b639"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5184), "Bộ sản phẩm Mô hình giấy kiến trúc Cambuchia Angkor Wat bao gồm:\r\n- 24 tờ kit mô hình.\r\n- 3 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/edb6286c7abf2d62a36a911b5d0983d4.webp", "Cambuchia Angkor Wat", 156000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5185) },
                    { new Guid("3bd9ee19-dca5-4b3a-ba71-f30588e4fcf6"), new Guid("a8c2a7b0-f586-42d1-bf49-11e02693b639"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5178), "Bộ sản phẩm Mô hình giấy kiến trúc Pháp tháp Eiffel Tower bao gồm:\r\n- 9 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/a077c0d85e3866a441e4b1e76ab69dbb.webp", "Eiffel Tower", 60000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5179) },
                    { new Guid("4776f7ee-3557-4f22-94a6-71454a4ac2c1"), new Guid("e6224088-98c3-452c-bd88-c004eec31463"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4940), "Bộ sản phẩm Mô hình giấy phi thuyền không gian vũ trụ tàu con thoi Space Shuttle Atlantis bao gồm:\r\n- 11 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/4ed6a6e35f435d28286762c02db7f911.webp", "Space Shuttle Atlantis", 72000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4941) },
                    { new Guid("604ed444-39b5-45de-873a-da8113845ae8"), new Guid("a3ade310-8d30-4aef-9bc8-f69823ec48a1"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4996), "Bộ sản phẩm Mô hình giấy Marvel Avenger Robot Iron Man Mark VII bao gồm:\r\n- 16 tờ kit mô hình.\r\n- 3 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/5fc4fc6d877bc7c905b6f92eeb951a94.webp", "Robot Iron Man Mark VII", 105000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4996) },
                    { new Guid("65824e04-351a-4821-a9eb-e0ca2ad2d36f"), new Guid("a3ade310-8d30-4aef-9bc8-f69823ec48a1"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5154), "Bộ sản phẩm Mô hình giấy Anime Game Chibi Doctor Strange - Marvel bao gồm:\r\n- 2 tờ kit mô hình + kèm scan code xem video hướng dẫn lắp ráp.\r\n* Xuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lzad737x2krla7@resize_w450_nl.webp", "Chibi Doctor Strange", 25000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5155) },
                    { new Guid("6abbee53-1cc0-4dcd-ad86-7bb33c4d87b9"), new Guid("1d3e2aea-8bff-43a3-b72e-1a5c0ad3e905"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4903), "Bộ sản phẩm Mô hình giấy Anime Chibi Monkey D Luffy - One Piece bao gồm:\r\n- 18 tờ kit mô hình.\r\n- Kích thước: Cao: 40cm x Rộng: 23,4cm x Sâu: 21,6cm", "https://down-vn.img.susercontent.com/file/e82a586f3d146ea83a3b6303b4668914.webp", "Monkey D. Luffy", 55000.0, "A4", 100, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4903) },
                    { new Guid("77f2054e-8157-494d-a9fd-7a10298d79c9"), new Guid("a8c2a7b0-f586-42d1-bf49-11e02693b639"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5170), "Bộ sản phẩm Mô hình giấy kiến trúc Tháp Luân Đôn Tower of London – England bao gồm:\r\n- 10 tờ kit mô hình.\r\n- 2 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/5e96e9613e2fd22d255d9d90159d19ce.webp", "Tower of London – England", 65000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5170) },
                    { new Guid("85ddd75c-e64f-44b7-8a7b-2824a7d6614f"), new Guid("1d3e2aea-8bff-43a3-b72e-1a5c0ad3e905"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4913), "Bộ sản phẩm Mô hình giấy Anime Game Pokemon Pikachu Polygon ver 2 bao gồm:\r\n- 9 tờ kit mô hình in mực Dầu trên giấy Màu.\r\n- 4 tờ hướng dẫn lắp ráp.\r\n- Kích thước A4: Cao: 33cm x Rộng: 30cm x Sâu: 34cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-ls9lvceatuah97@resize_w450_nl.webp", "Pikachu Polygon ver 2", 59000.0, "A4", 30, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4914) },
                    { new Guid("884034ef-443b-4b19-9f4a-dabced00bc5c"), new Guid("e6224088-98c3-452c-bd88-c004eec31463"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4983), "Bộ sản phẩm Mô hình giấy máy bay Boeing 777-200 British Airways bao gồm:\r\n- 8 tờ kit mô hình.\r\n- 1 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/a09cfa936019a5e6c493acafbd4a13e1.webp", "Boeing 777-200 British Airways", 58000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4984) },
                    { new Guid("c2f1b5d8-1598-4cde-a152-960eae07eabb"), new Guid("1d3e2aea-8bff-43a3-b72e-1a5c0ad3e905"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4887), "Bộ sản phẩm Mô hình giấy Anime Goku SSJ HD – Dragon Ball bao gồm:\r\n- 25 tờ kit mô hình.\r\n- Kích thước: Cao: 55,5cm x Rộng: 13,4cm x Sâu: 23,9cm", "https://down-vn.img.susercontent.com/file/ea93877ccd8d3700b6b9ede4220df541.webp", "Son Goku", 50000.0, "A4", 50, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4893) },
                    { new Guid("d6ce38da-861e-43a2-a909-686dc406a886"), new Guid("a8c2a7b0-f586-42d1-bf49-11e02693b639"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5163), "Bộ sản phẩm Mô hình giấy kiến trúc lâu đài Đức Neuschwanstein Castle - Germany bao gồm:\r\n- 8 tờ kit mô hình.\r\n- 2 tờ hướng dẫn lắp ráp.", "https://down-vn.img.susercontent.com/file/d50b7f9c059c8cb8e7c0654954a08ab1.webp", "Neuschwanstein Castle - Germany", 55000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5164) },
                    { new Guid("dccc7a03-d426-4e16-8530-323a03a71287"), new Guid("e6224088-98c3-452c-bd88-c004eec31463"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4947), "Bộ sản phẩm Mô hình giấy xe ô tô Lamborghini Sesto Elemento bao gồm:\r\n- 3 tờ kit mô hình.\r\n- Kích thước: Cao: 4,9cm x Rộng: 8,6cm x Sâu: 18,1cm", "https://down-vn.img.susercontent.com/file/966ca26a8de1b2f34c66449cc74e48bd.webp", "Lamborghini Sesto Elemento", 69000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4948) },
                    { new Guid("ea290f8a-d164-4e97-81f9-bc3535cbb41e"), new Guid("1d3e2aea-8bff-43a3-b72e-1a5c0ad3e905"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4932), "Bộ sản phẩm Mô hình giấy Anime Chibi Levi Ackerman ver 3 – Attack on Titan bao gồm:\r\n- 6 tờ kit mô hình.\r\n- Kích thước: Cao: 20,3cm x Rộng: 11,1cm x Sâu: 18cm", "https://down-vn.img.susercontent.com/file/a6da3b4677bd9309784051610617a5e7@resize_w450_nl.webp", "Chibi Levi Ackerman", 14000.0, "A4", 80, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(4933) },
                    { new Guid("ec615f88-3682-48ec-a0ac-b98695d2b49b"), new Guid("a3ade310-8d30-4aef-9bc8-f69823ec48a1"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5002), "Bộ sản phẩm Mô hình giấy Anime Game Chibi Thor mập - Marvel bao gồm:\r\n- 8 tờ kit mô hình in mực Dầu trên giấy Màu.\r\n- 2 tờ hướng dẫn lắp ráp.\r\n- Kích thước : Cao 15,5cm x Rộng 13cm x Sâu 9cm.\r\nXuất xứ: Việt Nam", "https://down-vn.img.susercontent.com/file/vn-11134207-7r98o-lmua3ev8pza778.webp", "Chibi Thor ", 50000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5003) },
                    { new Guid("f0efcfdd-3613-4596-8aa2-1e40abff1258"), new Guid("a3ade310-8d30-4aef-9bc8-f69823ec48a1"), new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5125), "Bộ sản phẩm Mô hình giấy Marvel Avengers Iron Spider bao gồm:\r\n- 15 tờ kit mô hình.\r\n- Kích thước: Cao: 38cm x Rộng: 30,7cm x Sâu: 34,5cm", "https://down-vn.img.susercontent.com/file/4b925257b8c606d8ba5549860b146ad1.webp", "Marvel Avengers Iron Spider", 100000.0, "A4", 10, new DateTime(2024, 10, 16, 15, 14, 35, 726, DateTimeKind.Local).AddTicks(5143) }
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
