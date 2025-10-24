using Microsoft.EntityFrameworkCore;
using QuanLyThongTinNguoiDung.DBContext;
using QuanLyThongTinNguoiDung.Models;
using QuanLyThongTinNguoiDung.Repositories.Interfaces;

namespace QuanLyThongTinNguoiDung.Repositories
{
    public class UserRepository : GennericRepository<UserModel>, IUserRepository
    {
        public UserRepository(UserDBContext dbContext) : base(dbContext)
        {
        }

        public Task<List<UserModel>> GetUsersForPage(int pageIndex, int pageSize)
        {
            var result = _dbContext.Users
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result;
        }
    }
}
