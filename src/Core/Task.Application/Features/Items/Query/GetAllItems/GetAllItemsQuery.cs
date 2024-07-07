using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Responses;

namespace Task.Application.Features.Items.Query.GetAllItems
{
    public class GetAllItemsQuery:IRequest<BaseResponse<List<ItemDto>>>
    {
    }
}
