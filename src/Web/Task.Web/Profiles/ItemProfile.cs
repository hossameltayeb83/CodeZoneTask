using AutoMapper;
using Task.Application.Features.Items.Query;
using Task.Web.ViewModels;

namespace Task.Web.Profiles
{
    public class ItemProfile :Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemDto, ItemViewModel>();
        }
    }
}
