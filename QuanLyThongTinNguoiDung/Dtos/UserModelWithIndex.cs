using QuanLyThongTinNguoiDung.Models;

namespace QuanLyThongTinNguoiDung.Dtos
{

    /// <summary>
    /// Thêm Index cho UserModel để hiển thị số thứ tự trong danh sách
    /// </summary>
    public class UserModelWithIndex:UserModel
    {
        public int Index { get; set; }
    }
}
