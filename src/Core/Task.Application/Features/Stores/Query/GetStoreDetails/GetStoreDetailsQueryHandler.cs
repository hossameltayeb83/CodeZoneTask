using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Application.Exceptions;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Stores.Query.GetStoreDetails
{
    internal class GetStoreDetailsQueryHandler : IRequestHandler<GetStoreDetailsQuery, BaseResponse<StoreDto>>
    {
        private readonly IRepository<Store> _storeRepository;
        private readonly IMapper _mapper;

        public GetStoreDetailsQueryHandler(IRepository<Store> repository,IMapper mapper)
        {
            _storeRepository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<StoreDto>> Handle(GetStoreDetailsQuery request, CancellationToken cancellationToken)
        {
            var response= new BaseResponse<StoreDto>();
            var store= await _storeRepository.GetByIdAsync(request.Id);
            if (store == null)
                throw new NotFoundException("Store Not Found");
            var storeDto=_mapper.Map<StoreDto>(store);
            response.Result = storeDto;
            return response;
        }
    }
}
