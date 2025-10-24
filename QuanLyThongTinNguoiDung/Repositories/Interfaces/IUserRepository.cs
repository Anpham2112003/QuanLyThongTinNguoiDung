using QuanLyThongTinNguoiDung.Models;

namespace QuanLyThongTinNguoiDung.Repositories.Interfaces
{
    public interface IUserRepository: IRepository<UserModel>
    {
        /// <summary>
        /// Lấy bản ghi người dùng theo phân trang 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Task<List<UserModel>> GetUsersForPage(int pageIndex, int pageSize);
    }
}
