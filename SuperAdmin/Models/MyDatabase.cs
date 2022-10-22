using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
    }
}
