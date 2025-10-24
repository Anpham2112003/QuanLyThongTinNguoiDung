using Microsoft.AspNetCore.Mvc;
using QuanLyThongTinNguoiDung.Models;
using QuanLyThongTinNguoiDung.Services.Interfaces;
using System.Threading.Tasks;

namespace QuanLyThongTinNguoiDung.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    public class UserController : Controller
    {
       
        private readonly IUserService _userService;


        /// <summary>
        /// Inject User Service vào Controller
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        /// <summary>
        /// Hiển thị danh sách người dùng theo phân trang , nếu không truyền tham số page thì mặc định là trang 1
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.CurrentPage = page;

            var datas = await _userService.GetUsersForPage(page);

            return View(datas);
        }



        /// <summary>
        /// Hiển thị form tạo mới người dùng
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }


        /// <summary>
        /// Tạo mới người dùng vào hệ thống
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                 (bool isSuccess , string message) = await _userService.AddUser(model);

                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(nameof(model.Email), message);

            }
            return View(model);
        }

        /// <summary>
        /// Hiển thị form chỉnh sửa người dùng
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var user = await _userService.GetUserById(Id);

            if (user is null)
            {
                return RedirectToAction("Index");
            }

            return View(user);
        }

        /// <summary>
        /// Câp nhập thông tin người dùng
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel model)
        {
            if (ModelState.IsValid)
            {
                (bool isSuccess , string message ) = await _userService.UpdateUser(model);

                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(nameof(model.Email), message);
            }

            return View(model);
        }


        /// <summary>
        /// Xoá người dùng khỏi hệ thống
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            (bool isSucess , string messsage) = await _userService.DeleteUser(Id);


            if (isSucess)
            {
                return Ok(messsage);
            }

            return BadRequest(messsage);
        }
    }
}
