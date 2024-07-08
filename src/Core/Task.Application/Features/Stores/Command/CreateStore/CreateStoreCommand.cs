using MediatR;
using Microsoft.AspNetCore.Http;
using Task.Application.Responses;

namespace Task.Application.Features.Stores.Command.CreateStore
{
    public class CreateStoreCommand :IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
    }
}
