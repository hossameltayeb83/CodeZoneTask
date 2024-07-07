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
            response.Result = await _storeItemRepository.GetStoreItemBalance(request.StoreId, request.ItemId);
            return response;
        }
    }
}
