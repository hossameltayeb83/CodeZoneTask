using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Application.Features.Stores.Query.GetStoreDetails;
using Task.Application.Features.Stores.Query;
using Task.Application.Responses;
using Task.Domain.Entities;
using Task.Application.Exceptions;

namespace Task.Application.Features.Items.Query.GetItemDetails
{
    internal class GetItemDetailsQueryHandler : IRequestHandler<GetItemDetailsQuery, BaseResponse<ItemDto>>
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public GetItemDetailsQueryHandler(IRepository<Item> repository, IMapper mapper)
        {
            _itemRepository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<ItemDto>> Handle(GetItemDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ItemDto>();

            var item = await _itemRepository.GetByIdAsync(request.Id);
            if (item == null)
                throw new NotFoundException("Item Not Found");

            var itemDto = _mapper.Map<ItemDto>(item);

            response.Result = itemDto;
            return response;
        }
    }
}
