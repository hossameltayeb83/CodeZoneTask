using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features.Stores.Command.CreateStore;
using Task.Application.Features.Stores.Command.UpdateStore;
using Task.Application.Features.Stores.Query;
using Task.Domain.Entities;

namespace Task.Application.Features.Stores
{
    internal class StoreProfile:Profile
    {
        public StoreProfile()
        {
            CreateMap<Store,StoreDto>();
            CreateMap<CreateStoreCommand, Store>();
            CreateMap<UpdateStoreCommand, Store>();
        }
    }
}
