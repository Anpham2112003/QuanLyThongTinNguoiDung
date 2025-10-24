using Microsoft.EntityFrameworkCore;
using QuanLyThongTinNguoiDung.DBContext;
using QuanLyThongTinNguoiDung.Repositories;
using QuanLyThongTinNguoiDung.Repositories.Interfaces;
using QuanLyThongTinNguoiDung.Services;
using QuanLyThongTinNguoiDung.Services.Interfaces;

namespace QuanLyThongTinNguoiDung
{
    public static class DependencyInjections
    {
        /// <summary>
        /// Mở rộng IServiceCollection để đăng ký các dịch vụ của ứng dụng
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Đăng ký các dịch vụ liên quan đến quản lý thông tin người dùng tại đây
            // Ví dụ: services.AddScoped<IUserService, UserService>();


            /// Đăng ký DbContext sử dụng In-Memory Database cho UserDBContext

            services.AddDbContext<UserDBContext>(op =>
            {
                op.UseInMemoryDatabase("UserDB");
                
            });

            /// Đăng ký UserRepository cho IUserRepository

            services.AddScoped<IUserRepository, UserRepository>();


            /// Đăng ký UserService cho IUserService
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
