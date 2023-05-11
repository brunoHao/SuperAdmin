using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperAdmin.Models.Shop;

namespace SuperAdmin.Models
{
    public class MyDatabase :IdentityDbContext<AppUser>
    {
        //options sẽ đc DI inject khi dịch vụ Myblogcontext được tạo ra.
        public MyDatabase(DbContextOptions<MyDatabase> options) : base(options)
        {

        }
        //luôn luôn nạp chồng OnConfiguring . nó sẽ hoạt động khi MyBlogContext được tạo ra.
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        //phương thức thường đucợ nạp chồng.
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<genPromoRight> genPromoRights { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
