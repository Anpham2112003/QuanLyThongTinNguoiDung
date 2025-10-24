using QuanLyThongTinNguoiDung.DBContext;
using QuanLyThongTinNguoiDung.Dtos;
using QuanLyThongTinNguoiDung.Models;
using QuanLyThongTinNguoiDung.Repositories.Interfaces;
using QuanLyThongTinNguoiDung.Services.Interfaces;
using System.Threading.Tasks;

namespace QuanLyThongTinNguoiDung.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<(bool, string)> AddUser(UserModel user)
        {
            var existingUser = await _userRepository.ExistAsync(x => x.Email == user.Email);

            if (existingUser)
            {
                return (false, "Email đã tồn tại trên hệ thống!");
            }

            await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync();

            return (true, "Thêm người dùng thành công!");
        }

        public async Task<(bool, string)> DeleteUser(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user  is null)
                return (false, "Người dùng không tồn tại trên hệ thống!");

            _userRepository.Delete(user);

            await _userRepository.SaveChangesAsync();

            return (true, "Xóa người dùng thành công!");
        }

        public async Task<(int Total, List<UserModelWithIndex>)> GetUsersForPage(int page)
        {
            var userDatas = await _userRepository.GetUsersForPage(page, 10);

            var totalUsers =await _userRepository.CountAysnc(_user => true);

            var userWithIndex = userDatas.Select((u, index) => new UserModelWithIndex
            {
                Index = (page - 1) * 10 + index + 1,
                Id = u.Id,
                HoTen = u.HoTen,
                Email = u.Email,
                DiaChi = u.DiaChi,
                NgaySinh = u.NgaySinh,
                SoDienThoai = u.SoDienThoai
            });

            return (totalUsers, userWithIndex.ToList());
        }

        public Task<UserModel?> GetUserById(Guid id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public async Task<(bool, string)> UpdateUser(UserModel user)
        {
            var updateUser = await _userRepository.FindAsync(u => u.Id == user.Id);

            if(updateUser is null)
                  return (false, "Người dùng không tồn tại trên hệ thống!");

            /// Kiểm tra email đã tồn tại trên một tài khoản khác không
            var checkEmail = await _userRepository.ExistAsync(u => u.Email == user.Email && u.Id != user.Id);

            if (checkEmail)
            {
                return (false, "Email đã tồn tại trên một tài khoản khác không thể cập nhập !");
            }

            updateUser.HoTen = user.HoTen;
            updateUser.Email = user.Email;
            updateUser.SoDienThoai = user.SoDienThoai;
            updateUser.DiaChi = user.DiaChi;
            updateUser.NgaySinh = user.NgaySinh;

            _userRepository.Update(updateUser);

            await _userRepository.SaveChangesAsync();


            return (true, "Cập nhật người dùng thành công!");
        }
    }
}
