using System.Threading.Tasks;
using FoodApi.Data;
using FoodApi.Reposities.interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Reposities
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        public EFRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(T entity)
        {
            await _db.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public IQueryable<T> Query()
        {
            return _db.Set<T>().AsQueryable();
        }

        public Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }
    }
}