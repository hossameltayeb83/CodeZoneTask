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
        private readonly IStoreItemRepository _storeItemRepository;

        public GetStoreItemBalanceQueryHandler(IStoreItemRepository storeItemRepository)
        {
            _storeItemRepository = storeItemRepository;
        }
        public async Task<BaseResponse<int>> Handle(GetStoreItemBalanceQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<int>();

            var storeItem= await _storeItemRepository.GetStoreItemAsync(request.StoreId, request.ItemId);

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
