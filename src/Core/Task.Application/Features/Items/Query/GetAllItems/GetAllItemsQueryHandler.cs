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

namespace Task.Application.Features.Items.Query.GetAllItems
{
    internal class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, BaseResponse<List<ItemDto>>>
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public GetAllItemsQueryHandler(IRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<ItemDto>>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<ItemDto>>();

            var items = await _itemRepository.GetALLAsync();
            var itemsDtos = _mapper.Map<List<ItemDto>>(items);

            response.Result = itemsDtos;
            return response;
        }
    }
}
