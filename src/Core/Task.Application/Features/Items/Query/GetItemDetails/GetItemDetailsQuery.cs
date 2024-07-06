using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Responses;

namespace Task.Application.Features.Items.Query.GetItemDetails
{
    public class GetItemDetailsQuery:IRequest<BaseResponse<ItemDto>>
    {
        public int Id { get; set; }
    }
}
