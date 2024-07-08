using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features.StoreItems.Command.UpdateStoreItem;
using Task.Application.Features.Stores.Command.UpdateStore;
using Task.Domain.Entities;

namespace Task.Application.Features.StoreItems
{
    internal class StoreItemProfile : Profile
    {
        public StoreItemProfile()
        {
            CreateMap<UpdateStoreItemCommand, StoreItem>();
        }
    }
}
