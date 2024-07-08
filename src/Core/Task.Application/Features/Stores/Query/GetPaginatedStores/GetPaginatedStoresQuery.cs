using MediatR;
using Task.Application.Responses;

namespace Task.Application.Features.Stores.Query.GetPaginatedStores
{
    public class GetPaginatedStoresQuery : IRequest<BaseResponse<PaginatedResponse<StoreDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
