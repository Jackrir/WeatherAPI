using DataLayer.Entities.Base;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class Repository : IRepository
    {
        private readonly AppDBContext DbContext;

        public Repository(AppDBContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<T> AddAsync<T>(T element) where T : BaseEntity
        {
            var newElementTask = await DbContext.Set<T>().AddAsync(element);
            await DbContext.SaveChangesAsync();
            return newElementTask.Entity;
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> range) where T : BaseEntity
        {
            await DbContext.Set<T>().AddRangeAsync(range);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T element) where T : BaseEntity
        {
            DbContext.Set<T>().Remove(element);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync<T>(IEnumerable<T> range) where T : BaseEntity
        {
            DbContext.Set<T>().RemoveRange(range);
            await DbContext.SaveChangesAsync();
        }

        public T Get<T>(Func<T, bool> predicate) where T : BaseEntity
        {
            IQueryable<T> query = DbContext.Set<T>();
            return query.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetRange<T>(Func<T, bool> predicate) where T : BaseEntity
        {
            IQueryable<T> query = DbContext.Set<T>();
            return query.Where(predicate);
        }

        public async Task UpdateAsync<T>(T element) where T : BaseEntity
        {
            DbContext.Set<T>().Update(element);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync<T>(IEnumerable<T> range) where T : BaseEntity
        {
            DbContext.Set<T>().UpdateRange(range);
            await DbContext.SaveChangesAsync();
        }
    }
}
