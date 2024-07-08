using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Contracts.Persistence
{
    public interface IStoreItemRepository : IRepository<StoreItem>
    {
        public Task<StoreItem?> GetStoreItemAsync(int storeId, int itemId);
    }
}
