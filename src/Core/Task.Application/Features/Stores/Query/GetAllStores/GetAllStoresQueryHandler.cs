using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Application.Features.Items.Query;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Stores.Query.GetAllStores
{
    internal class GetAllStoresQueryHandler : IRequestHandler<GetAllStoresQuery, BaseResponse<List<StoreDto>>>
    {
        private readonly IRepository<Store> _storeRepository;
        private readonly IMapper _mapper;

        public GetAllStoresQueryHandler(IRepository<Store> storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<StoreDto>>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<StoreDto>>();

            var stores = await _storeRepository.GetALLAsync();
            var storesDto = _mapper.Map<List<StoreDto>>(stores);

            response.Result = storesDto;
            return response;
        }
    }
}
