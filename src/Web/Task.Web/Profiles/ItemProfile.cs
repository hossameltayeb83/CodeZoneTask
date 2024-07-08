using AutoMapper;
using Task.Application.Features.Items.Query;
using Task.Application.Features.Stores.Query;
using Task.Application.Responses;
using Task.Web.ViewModels;

namespace Task.Web.Profiles
{
    public class ItemProfile :Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemDto, ItemViewModel>();
            CreateMap<PaginatedResponse<ItemDto>, PaginatedViewModel<List<ItemViewModel>>>();
        }
    }
}
