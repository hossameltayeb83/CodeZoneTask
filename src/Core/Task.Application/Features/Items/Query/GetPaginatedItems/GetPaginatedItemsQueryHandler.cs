using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features.Stores.Query.GetPaginatedStores;
using Task.Application.Features.Stores.Query;
using Task.Application.Responses;
using AutoMapper;
using Task.Application.Contracts.Persistence;
using Task.Domain.Entities;

namespace Task.Application.Features.Items.Query.GetPaginatedItems
{
    internal class GetPaginatedItemsQueryHandler : IRequestHandler<GetPaginatedItemsQuery, BaseResponse<PaginatedResponse<ItemDto>>>
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public GetPaginatedItemsQueryHandler(IRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<PaginatedResponse<ItemDto>>> Handle(GetPaginatedItemsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<PaginatedResponse<ItemDto>>();
            var items = await _itemRepository.GetPaginatedListAsync(request.Page, request.PageSize);
            var itemsDto = _mapper.Map<List<ItemDto>>(items.Items);
            response.Result = new PaginatedResponse<ItemDto>(itemsDto, request.Page, request.PageSize, items.Count);
            return response;
        }
    }
}
