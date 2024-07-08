using MediatR;
using Microsoft.AspNetCore.Http;
using Task.Application.Responses;

namespace Task.Application.Features.Stores.Command.UpdateStore
{
    public class UpdateStoreCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile? Image {  get; set; }
    }
}
