using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace QuanLyThongTinNguoiDung.Models
{
    /// <summary>
    /// Model người dùng để Bind dữ liệu từ Form
    /// </summary>
    public class UserModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên tối đa 100 ký tự")]
        public  string HoTen { get; set; } =string .Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public  string Email { get; set; } =string .Empty;

        [Required(ErrorMessage = "Ngày sinh không được để trống")]

        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }


        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [RegularExpression(@"^(0|\+84)([0-9]{9})$", ErrorMessage = "Số điện thoại không hợp lệ!")]
        public  string SoDienThoai { get; set; } =string .Empty;

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string DiaChi { get; set; } =string .Empty;



    }
}
