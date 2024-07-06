using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Stores.Query.GetPaginatedStores
{
    internal class GetPaginatedStoresQueryHandler : IRequestHandler<GetPaginatedStoresQuery, BaseResponse<PaginatedResponse<StoreDto>>>
    {
        private readonly IRepository<Store> _storeRepository;
        private readonly IMapper _mapper;

        public GetPaginatedStoresQueryHandler(IRepository<Store> storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<PaginatedResponse<StoreDto>>> Handle(GetPaginatedStoresQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PaginatedResponse<StoreDto>>();
            var stores = await _storeRepository.GetPaginatedListAsync(request.Page, request.PageSize);
            var storesDto = _mapper.Map<List<StoreDto>>(stores.Items);
            response.Result = new PaginatedResponse<StoreDto>(storesDto, request.Page, request.PageSize, stores.Count);
            return response;
        }
    }
}
