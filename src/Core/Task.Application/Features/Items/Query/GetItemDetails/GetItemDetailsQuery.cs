using MediatR;
using Task.Application.Responses;

namespace Task.Application.Features.Items.Query.GetItemDetails
{
    public class GetItemDetailsQuery : IRequest<BaseResponse<ItemDto>>
    {
        public int Id { get; set; }
    }
}
