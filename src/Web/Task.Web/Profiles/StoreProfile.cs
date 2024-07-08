using AutoMapper;
using Task.Application.Features.Stores.Query;
using Task.Application.Responses;
using Task.Web.ViewModels;

namespace Task.Web.Profiles
{
    public class StoreProfile:Profile
    {
        public StoreProfile()
        {
            CreateMap<StoreDto,StoreViewModel>();
            CreateMap<PaginatedResponse<StoreDto>, PaginatedViewModel<List<StoreViewModel>>>();
        }
    }
}
