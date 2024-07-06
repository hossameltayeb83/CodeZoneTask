using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features.Items.Command.CreateItem;
using Task.Application.Features.Items.Command.UpdateItem;
using Task.Application.Features.Items.Query;
using Task.Application.Features.Stores.Command.CreateStore;
using Task.Application.Features.Stores.Command.UpdateStore;
using Task.Application.Features.Stores.Query;
using Task.Domain.Entities;

namespace Task.Application.Features.Items
{
    internal class ItemProfile:Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<CreateItemCommand, Item>();
            CreateMap<UpdateItemCommand, Item>();
        }
    }
}
