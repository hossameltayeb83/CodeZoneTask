using MediatR;
using Task.Application.Responses;

namespace Task.Application.Features.Items.Command.DeleteItem
{
    public class DeleteItemCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
