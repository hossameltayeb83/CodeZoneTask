using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features.Stores.Query;
using Task.Application.Responses;

namespace Task.Application.Features.Items.Query.GetPaginatedItems
{
    public class GetPaginatedItemsQuery: IRequest<BaseResponse<PaginatedResponse<ItemDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
