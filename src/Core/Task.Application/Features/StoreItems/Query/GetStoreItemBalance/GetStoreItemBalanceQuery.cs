using MediatR;
using Task.Application.Responses;

namespace Task.Application.Features.StoreItems.Query.GetStoreItemBalance
{
    public class GetStoreItemBalanceQuery : IRequest<BaseResponse<int>>
    {
        public int StoreId { get; set; }
        public int ItemId { get; set; }
    }
}
