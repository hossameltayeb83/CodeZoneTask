using MediatR;
using Task.Application.Responses;

namespace Task.Application.Features.Items.Query.GetAllItems
{
    public class GetAllItemsQuery : IRequest<BaseResponse<List<ItemDto>>>
    {
    }
}
