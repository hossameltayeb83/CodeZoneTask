using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Task.Application.Responses;
using Task.Domain.Enums;

namespace Task.Application.Features.StoreItems.Command.UpdateStoreItem
{
    public class UpdateStoreItemCommand: IRequest<BaseResponse>
    {
        public int StoreId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public TransactionType Transaction { get; set; }
    }
}
