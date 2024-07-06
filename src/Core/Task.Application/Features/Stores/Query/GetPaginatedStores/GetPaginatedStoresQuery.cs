using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Responses;

namespace Task.Application.Features.Stores.Query
{
    public class GetPaginatedStoresQuery:IRequest<BaseResponse<PaginatedResponse<StoreDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
