using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Domain.Entities;
using Task.Persistence.Data;

namespace Task.Persistence.Repositories
{
    public class StoreItemRepository : BaseRepository<StoreItem>, IStoreItemRepository
    {
        public StoreItemRepository(TaskContext context) : base(context)
        {
        }

        public async Task<StoreItem?> GetStoreItemAsync(int storeId, int itemId)
        {
            return await _context.StoreItems.FirstOrDefaultAsync(e=>e.StoreId==storeId&& e.ItemId==itemId);
        }
    }
}
