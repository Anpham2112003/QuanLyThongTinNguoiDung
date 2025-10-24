using QuanLyThongTinNguoiDung.Dtos;
using QuanLyThongTinNguoiDung.Models;

namespace QuanLyThongTinNguoiDung.Services.Interfaces
{
    /// <summary>
    /// Tạo Service cho User
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Lấy danh sách người dùng theo trang kèm index và số lượng người dùng
        /// </summary>
        /// <param name="page"></param>
        /// <returns>Trả về Tổng số bản ghi và danh sách User đã được phân trang</returns>
        public Task<(int Total, List<UserModelWithIndex>)> GetUsersForPage(int page);

        /// <summary>
        /// Tìm kiếm người dùng theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Trả về User nếu không có trả về null</returns>
        public Task<UserModel?> GetUserById(Guid id);

        /// <summary>
        /// Thêm mới người dùng vào cơ sở dữ liệu 
        /// </summary>
        /// <param name="user"></param>
        /// <returns> Trả về Tuple bool and string</returns>
        public Task<(bool, string)> AddUser(UserModel user);

        /// <summary>
        /// Cập nhập thông tin người dùng , trả về trạng thái và thông báo
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<(bool, string)> UpdateUser(UserModel user);

        /// <summary>
        /// Xoá người dùng khỏi hệ thống , trả về trạng thái và thông báo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<(bool, string)> DeleteUser(Guid id);
    }
}
