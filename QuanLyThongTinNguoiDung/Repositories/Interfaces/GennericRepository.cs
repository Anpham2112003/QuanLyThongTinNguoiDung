
using Microsoft.EntityFrameworkCore;
using QuanLyThongTinNguoiDung.DBContext;
using System.Linq.Expressions;

namespace QuanLyThongTinNguoiDung.Repositories.Interfaces
{
    public class GennericRepository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly UserDBContext _dbContext;

        public GennericRepository(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TModel model)
        {
             await _dbContext.Set<TModel>().AddAsync(model);

        }

        public void Delete(TModel model)
        {
            _dbContext.Remove(model);
        }

      

        public Task<List<TModel>> GetAllAsync()
        {
            return _dbContext.Set<TModel>().ToListAsync();
        }

        public Task<TModel?> GetByIdAsync(Guid id)
        {
            return _dbContext.Set<TModel>().FindAsync(id).AsTask();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Update(TModel model)
        {
             _dbContext.Set<TModel>().Update(model);
        }

        public Task<bool> ExistAsync(Expression<Func<TModel, bool>> predicate)
        {
            return _dbContext.Set<TModel>().AnyAsync(predicate);
        }

        public Task<int> CountAysnc(Expression<Func<TModel, bool>> predicate)
        {
            return _dbContext.Set<TModel>().CountAsync(predicate);
        }

        public Task<TModel?> FindAsync(Expression<Func<TModel, bool>> predicate)
        {
            return _dbContext.Set<TModel>().FirstOrDefaultAsync(predicate);
        }
    }
}
