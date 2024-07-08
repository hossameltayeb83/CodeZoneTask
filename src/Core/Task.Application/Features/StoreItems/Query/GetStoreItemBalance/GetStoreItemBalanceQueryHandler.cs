using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.StoreItems.Query.GetStoreItemBalance
{
    internal class GetStoreItemBalanceQueryHandler : IRequestHandler<GetStoreItemBalanceQuery, BaseResponse<int>>
    {
        private readonly IRepository<StoreItem> _storeItemRepository;

        public GetStoreItemBalanceQueryHandler(IRepository<StoreItem> storeItemRepository)
        {
            _storeItemRepository = storeItemRepository;
        }
        public async Task<BaseResponse<int>> Handle(GetStoreItemBalanceQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<int>();

            var storeItem= await _storeItemRepository.GetByIdAsync(request.ItemId, request.StoreId);

            if (storeItem!=null)
            {
                response.Result = storeItem.Quantity;
            }
            else
            {
                response.Result = 0;
            }

            return response;
        }
    }
}
