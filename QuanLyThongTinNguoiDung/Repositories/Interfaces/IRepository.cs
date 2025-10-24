using System.Linq.Expressions;

namespace QuanLyThongTinNguoiDung.Repositories.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {
        /// <summary>
        /// Thêm mới một bản ghi vào cơ sở dữ liệu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task AddAsync(TModel model);

        /// <summary>
        /// Cập nhập bản ghi trong cơ sở dữ liệu
        /// </summary>
        /// <param name="model"></param>
        public void Update(TModel model);

        /// <summary>
        /// Xoá bản ghi khỏi cơ sở dữ liệu
        /// </summary>
        /// <param name="model"></param>
        public void Delete(TModel model);

        /// <summary>
        /// Tìm kiếm bản ghi theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> </returns>
        public Task<TModel?> GetByIdAsync(Guid id);

        /// <summary>
        /// Tìm kiếm bản ghi theo điều kiện
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<TModel?> FindAsync(Expression<Func<TModel, bool>> predicate);

        /// <summary>
        /// Lấy tất cả bản ghi trong bảng
        /// </summary>
        /// <returns></returns>
        public Task<List<TModel>> GetAllAsync();

        /// <summary>
        /// Kiểm tra bản ghi có tồn tại theo điều kiện không
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<bool> ExistAsync(Expression<Func<TModel, bool>> predicate);

        /// <summary>
        /// Đếm số bản ghi theo điều kiện
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<int> CountAysnc(Expression<Func<TModel, bool>> predicate );

        /// <summary>
        /// Lưu thay đổi vào cơ sở dữ liệu
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync();
    }
}
