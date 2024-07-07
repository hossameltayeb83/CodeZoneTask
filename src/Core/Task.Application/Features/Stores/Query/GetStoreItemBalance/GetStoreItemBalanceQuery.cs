using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Responses;

namespace Task.Application.Features.Stores.Query.GetStoreItemBalance
{
    public class GetStoreItemBalanceQuery: IRequest<BaseResponse<int>>
    {
        public int StoreId { get; set; }
        public int ItemId { get; set; }
    }
}
