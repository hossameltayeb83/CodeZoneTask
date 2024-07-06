using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features.Stores.Query;
using Task.Application.Responses;

namespace Task.Application.Features.Stores.Command.CreateStore
{
    public class CreateStoreCommand :IRequest<BaseResponse<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
    }
}
