using Microsoft.EntityFrameworkCore;
using HotelManagement.DbContext;
using HotelManagement.Models;
using HotelManagement.Repositories.Interfaces;
using System.Linq.Expressions;

namespace HotelManagement.Repositories
{
    public class BaseRepo<T, K> : IBaseRepo<T, K> where T : BaseEntity<K>
    {
        private readonly AppDbContext _context;

        public BaseRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(K id)
        {
            var entity = await FindById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    items = items.Include(include);
                }
            }
            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    items = items.Include(include);
                }
            }
            return items.Where(predicate);
        }

        public async Task<T> FindById(K id , params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    items = items.Include(include);
                }
            }
            return await items.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task Update(T entity , params string[] propertiesToExclue)
        {
            _context.Set<T>().Attach(entity);
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            foreach (var item in propertiesToExclue)
            {
                entry.Property(item).IsModified = false;
            }
            await _context.SaveChangesAsync();
        }
    }
}
