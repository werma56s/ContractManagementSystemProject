using ContractManagementSystem.DAL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContractManagementSystem.DAL.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll() => _dbSet;

        public T GetById(Guid id) => _dbSet.Find(id);

        public void Add(T entity) => _dbSet.Add(entity);

        public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;

        public void Delete(T entity) => _dbSet.Remove(entity);
    }
}
