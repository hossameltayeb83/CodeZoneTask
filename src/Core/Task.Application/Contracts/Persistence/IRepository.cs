using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : class
    {
        ValueTask<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetALLAsync();
        Task<(IReadOnlyList<T> Items, int Count)> GetPaginatedListAsync(int page, int pageSize);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
