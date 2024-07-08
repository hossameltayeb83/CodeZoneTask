using AutoMapper;
using Task.Application.Features.Items.Command.CreateItem;
using Task.Application.Features.Items.Command.UpdateItem;
using Task.Application.Features.Items.Query;
using Task.Domain.Entities;

namespace Task.Application.Features.Items
{
    internal class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<CreateItemCommand, Item>();
            CreateMap<UpdateItemCommand, Item>();
        }
    }
}
