using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Stores.Query.GetStoreItemBalance
{
    //internal class GetStoreItemBalanceQueryHandler : IRequestHandler<GetStoreItemBalanceQuery, BaseResponse<int>>
    //{
        //private readonly IStoreRepository _storeRepository;

        //public GetStoreItemBalanceQueryHandler(IStoreRepository storeRepository)
        //{
        //    _storeRepository = storeRepository;
        //}
        //public async Task<BaseResponse<int>> Handle(GetStoreItemBalanceQuery request, CancellationToken cancellationToken)
        //{
        //    var response = new BaseResponse<int>();
        //    response.Result = await _storeRepository.GetItemBalance(request.StoreId, request.ItemId);
        //    return response;
        //}
    //}
}
