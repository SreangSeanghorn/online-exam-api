using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Contract;
using TodoApi.Data;

namespace TodoApi.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StudentDBContext context;
        public GenericRepository(StudentDBContext context)
        {
            this.context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            // context.DisposeAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            context.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public Task<List<T>> GetAllAsync()
        {
           return Task.FromResult(context.Set<T>().ToList());
        }

        public async Task<T> GetAsync(int id)
        {
            // var res = await context.Set<T>().FindAsync(id);
            // return res;
            return Task.FromResult(context.Set<T>().Find(id)).Result;

        }

        public Task<bool> IsExists(int id)
        {
           return Task.FromResult(context.Set<T>().Any(e => e.Id == id));
        }

        public Task<T> UpdateAsync(T entity)
        {
            return Task.FromResult(context.Update(entity).Entity);
        }
    }
   
}