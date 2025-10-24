using Microsoft.EntityFrameworkCore;
using QuanLyThongTinNguoiDung.Models;

namespace QuanLyThongTinNguoiDung.DBContext
{
    public class UserDBContext:DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

    

        public DbSet<UserModel> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDBContext).Assembly);
        }
    }
}
