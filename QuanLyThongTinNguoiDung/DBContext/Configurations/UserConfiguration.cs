using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyThongTinNguoiDung.Models;

namespace QuanLyThongTinNguoiDung.DBContext.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.HoTen).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.NgaySinh).IsRequired();
            builder.Property(u => u.SoDienThoai).IsRequired();
            builder.Property(u => u.DiaChi).IsRequired();

            builder.HasIndex(x => x.Email);

        }
    }
}
