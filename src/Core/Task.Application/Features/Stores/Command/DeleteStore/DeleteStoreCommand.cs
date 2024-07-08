using MediatR;
using Task.Application.Responses;

namespace Task.Application.Features.Stores.Command.DeleteStore
{
    public class DeleteStoreCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
