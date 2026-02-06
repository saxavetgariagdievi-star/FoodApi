namespace FoodApi.Reposities.interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
        IQueryable<T> Query();
    }
}