using MediatR;
using Task.Application.Responses;

namespace Task.Application.Features.Stores.Query.GetAllStores
{
    public class GetAllStoresQuery : IRequest<BaseResponse<List<StoreDto>>>
    {
    }
}
