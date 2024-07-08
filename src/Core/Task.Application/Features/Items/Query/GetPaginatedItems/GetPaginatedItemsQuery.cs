using MediatR;
using Task.Application.Responses;

namespace Task.Application.Features.Items.Query.GetPaginatedItems
{
    public class GetPaginatedItemsQuery : IRequest<BaseResponse<PaginatedResponse<ItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
