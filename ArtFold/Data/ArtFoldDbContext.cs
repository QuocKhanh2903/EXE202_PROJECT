using ArtFold.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace ArtFold.Data
{
    public class ArtFoldDbContext : IdentityDbContext<User> 
    {
        public DbSet<User> Users {  get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CheckOut> CheckOuts { get; set; }

        public ArtFoldDbContext(DbContextOptions<ArtFoldDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CartProduct>()
                .HasKey(cp => new { cp.CartID, cp.ProductID });

            builder.Entity<CartProduct>()
                .HasOne(cp => cp.Cart)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(cp => cp.CartID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CartProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(cp => cp.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderID, op.ProductID });

            builder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderID)
                .OnDelete(DeleteBehavior.Cascade);


            SeedData(builder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var adminRoleId = Guid.NewGuid().ToString();
            var customerRoleId = Guid.NewGuid().ToString();

            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = customerRoleId,
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
            );

            var users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Admin",
                    Email = "bluegameming292003@gmail.com",
                    EmailConfirmed = true,
                    FullName = "Trần Minh Quốc Khánh",
                    PhoneNumber = "0934763210",
                    CreatedAt = DateTime.Now,
                    PasswordHash = hasher.HashPassword(null, "admin")
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "TaiModel",
                    Email = "taimodel@gmail.com",
                    EmailConfirmed = true,
                    FullName = "Nguyễn Lương Tài",
                    PhoneNumber = "0123456789",
                    CreatedAt = DateTime.Now,
                    PasswordHash = hasher.HashPassword(null, "tai123")
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "MinhThu",
                    Email = "dinhuynhminhthu@gmail.com",
                    EmailConfirmed = true,
                    FullName = "Đinh Huỳnh Minh Thư",
                    PhoneNumber = "0123456789",
                    CreatedAt = DateTime.Now,
                    PasswordHash = hasher.HashPassword(null, "thu123")
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "NgocHa",
                    Email = "ngocha@gmail.com",
                    EmailConfirmed = true,
                    FullName = "Ngọc Hà",
                    PhoneNumber = "0123456789",
                    CreatedAt = DateTime.Now,
                    PasswordHash = hasher.HashPassword(null, "ha123")
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "NgocHan",
                    Email = "nguyenvungochan@gmail.com",
                    EmailConfirmed = true,
                    FullName = "Nguyễn Vũ Ngọc Hân",
                    PhoneNumber = "0123456789",
                    CreatedAt = DateTime.Now,
                    PasswordHash = hasher.HashPassword(null, "han123")
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "ThuIT",
                    Email = "thuIT@gmail.com",
                    EmailConfirmed = true,
                    FullName = "Thư AI",
                    PhoneNumber = "0123456789",
                    CreatedAt = DateTime.Now,
                    PasswordHash = hasher.HashPassword(null, "thuit123")
                }
            };

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = users[0].Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = customerRoleId,
                    UserId = users[1].Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = customerRoleId,
                    UserId = users[2].Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = customerRoleId,
                    UserId = users[3].Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = customerRoleId,
                    UserId = users[4].Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = customerRoleId,
                    UserId = users[5].Id
                }
            );

            var categories = new List<Category>
            {
                new Category
                {
                    CategoryID = Guid.NewGuid(),
                    CategoryName = "Anime"
                },
                new Category
                {
                    CategoryID = Guid.NewGuid(),
                    CategoryName = "Vehicle"
                },
                new Category
                {
                    CategoryID = Guid.NewGuid(),
                    CategoryName = "Marvel"
                },
                new Category
                {
                    CategoryID = Guid.NewGuid(),
                    CategoryName = "Architecture"
                }
            };

            var products = new List<Product>
            {
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Anime").CategoryID,
                    Name = "Son Goku",
                    ImgUrl = "https://e7.pngegg.com/pngimages/617/624/png-clipart-dragonball-son-goku-goku-gohan-vegeta-super-saiya-dragon-ball-dragon-ball-z-superhero-hand.png",
                    PrintPaperType = "A4",
                    Price = 9.99,
                    ProductQuantity = 50,
                    Description = "This is a Son Goku fold model set",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,   
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Anime").CategoryID,
                    Name = "Monkey D. Luffy",
                    ImgUrl = "https://wibu.com.vn/wp-content/uploads/2024/04/Monkey-D-Luffy.png",
                    PrintPaperType = "A4",
                    Price = 4.99,
                    ProductQuantity = 100,
                    Description = "This is a Luffy fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Anime").CategoryID,
                    Name = "Naruto",
                    ImgUrl = "https://naruto.vn/wp-content/uploads/2023/05/char_naruto.webp",
                    PrintPaperType = "A4",
                    Price = 19.99,
                    ProductQuantity = 30,
                    Description = "This is a Naruto fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Anime").CategoryID,
                    Name = "Pikachu",
                    ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSFyZHb1xRALpxnlM7JNL6HeKlk0z5-fVv0Yw&s",
                    PrintPaperType = "A4",
                    Price = 3.59,
                    ProductQuantity = 30,
                    Description = "This is a Pikachu fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Anime").CategoryID,
                    Name = "Levi",
                    ImgUrl = "https://external-preview.redd.it/Yh3aHaFOjKi47VCJLPO2dNw27LojX6y9WL0OMj8HeaA.png?auto=webp&s=dabd03ed4c864fa3600efdd51499b036848b989d",
                    PrintPaperType = "A4",
                    Price = 59.99,
                    ProductQuantity = 80,
                    Description = "This is a Levi AOT fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Vehicle").CategoryID,
                    Name = "General Dynamics F-111",
                    ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/6/6a/An_air-to-air_left_front_view_of_an_F-111_aircraft_during_a_refueling_mission_over_the_North_Sea_DF-ST-89-03609_%28altered%29.jpg",
                    PrintPaperType = "A4",
                    Price = 29.99,
                    ProductQuantity = 10,
                    Description = "This is a military aircraft General Dynamics fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Vehicle").CategoryID,
                    Name = "SU-22",
                    ImgUrl = "https://media-cdn-v2.laodong.vn/Storage/newsportal/2018/7/27/621630/Su22m.jpg",
                    PrintPaperType = "A4",
                    Price = 49.99,
                    ProductQuantity = 10,
                    Description = "This is a military aircraft SU-22 fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Vehicle").CategoryID,
                    Name = "F/A-18 Hornet",
                    ImgUrl = "http://genk.mediacdn.vn/2013/fa18_hornet-4305c.jpg",
                    PrintPaperType = "A4",
                    Price = 49.99,
                    ProductQuantity = 10,
                    Description = "This is a military aircraft F/A-18 Hornet fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Vehicle").CategoryID,
                    Name = "EA-18G Growler",
                    ImgUrl = "http://genk.mediacdn.vn/2013/ea18g_growler-4305c.jpg",
                    PrintPaperType = "A4",
                    Price = 49.99,
                    ProductQuantity = 10,
                    Description = "This is a military aircraft EA-18G Growler fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Vehicle").CategoryID,
                    Name = "F-35 Lightning II",
                    ImgUrl = "http://genk.mediacdn.vn/2013/f35_lightning2-4305c.jpg",
                    PrintPaperType = "A4",
                    Price = 29.99,
                    ProductQuantity = 10,
                    Description = "This is a military aircraft F-35 Lightning II fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Marvel").CategoryID,
                    Name = "Iron Man",
                    ImgUrl = "https://static.wikia.nocookie.net/endless-fictional-arena/images/c/c3/Mark_50.png/revision/latest/scale-to-width-down/400?cb=20240123110416&path-prefix=vi",
                    PrintPaperType = "A4",
                    Price = 5.99,
                    ProductQuantity = 10,
                    Description = "This is a Iron Man fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Marvel").CategoryID,
                    Name = "Thor",
                    ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/81ec9J+H0XL.jpg",
                    PrintPaperType = "A4",
                    Price = 7.99,
                    ProductQuantity = 10,
                    Description = "This is a Thor fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Marvel").CategoryID,
                    Name = "Hulk",
                    ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/61D3Kg-apuL.jpg",
                    PrintPaperType = "A4",
                    Price = 8.99,
                    ProductQuantity = 10,
                    Description = "This is a Hulk fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Marvel").CategoryID,
                    Name = "Spider Man",
                    ImgUrl = "https://imagev3.vietnamplus.vn/w1000/Uploaded/2024/lepz/2015_02_11/spider.jpg.webp",
                    PrintPaperType = "A4",
                    Price = 4.99,
                    ProductQuantity = 10,
                    Description = "This is a Spider-Man fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Marvel").CategoryID,
                    Name = "Doctor Strange",
                    ImgUrl = "https://static.wikia.nocookie.net/disney/images/d/dc/Doctor_Strange_-_Profile.png/revision/latest?cb=20220804200852",
                    PrintPaperType = "A4",
                    Price = 3.99,
                    ProductQuantity = 10,
                    Description = "This is a Doctor Strange fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Architecture").CategoryID,
                    Name = "Petronas Twin Tower",
                    ImgUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/85/Petronas_Panorama_II.jpg/1200px-Petronas_Panorama_II.jpg",
                    PrintPaperType = "A4",
                    Price = 13.99,
                    ProductQuantity = 10,
                    Description = "This is a Petronas Twin Tower fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Architecture").CategoryID,
                    Name = "Vatican Cathedral",
                    ImgUrl = "https://mia.vn/media/uploads/blog-du-lich/vuong-cung-thanh-duong-thanh-phero-1-1705624912.jpeg",
                    PrintPaperType = "A4",
                    Price = 23.99,
                    ProductQuantity = 10,
                    Description = "This is a Vatican fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Architecture").CategoryID,
                    Name = "Paris Tower",
                    ImgUrl = "https://www.startravel.vn/upload/tintuc/cau-truc-thap-eiffel/tham-quan-Thap-Eiffel.jpg",
                    PrintPaperType = "A4",
                    Price = 73.99,
                    ProductQuantity = 10,
                    Description = "This is a Paris Tower fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Architecture").CategoryID,
                    Name = "Landmark 81",
                    ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7xLbIO3WCxa93dKqiImlSU0VAXyOKOj5Z_w&s",
                    PrintPaperType = "A4",
                    Price = 13.99,
                    ProductQuantity = 10,
                    Description = "This is a Landmark81 Tower fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Product
                {
                    ProductID = Guid.NewGuid(),
                    CategoryID = categories.First(c => c.CategoryName == "Architecture").CategoryID,
                    Name = "Church",
                    ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTnm6dJzUo2Byymnsn69_7BcpdEmsyJWFu0nw&s",
                    PrintPaperType = "A4",
                    Price = 23.99,
                    ProductQuantity = 10,
                    Description = "This is a Main Church fold model set.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                }
            };

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Category>().HasData(categories);

        }
    }
}
