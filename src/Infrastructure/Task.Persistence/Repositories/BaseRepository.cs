using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Persistence.Data;
namespace Task.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly TaskContext _context;

        public BaseRepository(TaskContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IReadOnlyList<T>> GetALLAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async ValueTask<T?> GetByIdAsync(params int[] ids)
        {
            T? result;
            object[] keys = ids.Cast<object>().ToArray();
            result = await _context.Set<T>().FindAsync(keys);
            //if (ids.Length == 1)
            //{
            //    result= await _context.Set<T>().FindAsync(ids[0]);
            //}
            //else
            //{
            //    result = await _context.Set<T>().FindAsync(ids[0], ids[1]);
            //}
            return result;
        }

        public async Task<(IReadOnlyList<T>,int)> GetPaginatedListAsync(int page, int pageSize)
        {
            var result= await _context.Set<T>().GroupBy(e=>1).Select(e=> new
            {
                Count=e.Count(),
                Items=e.Skip((page - 1) * pageSize).Take(pageSize).ToList()
            }).FirstOrDefaultAsync();
            return (result.Items, result.Count);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
