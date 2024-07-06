using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Responses;

namespace Task.Application.Features.Stores.Query.GetStoreDetails
{
    public class GetStoreDetailsQuery:IRequest<BaseResponse<StoreDto>>
    {
        public int Id { get; set; }
    }
}
