using MediatR;
using Task.Application.Responses;

namespace Task.Application.Features.Stores.Query.GetStoreDetails
{
    public class GetStoreDetailsQuery : IRequest<BaseResponse<StoreDto>>
    {
        public int Id { get; set; }
    }
}
