using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Application.Features.Stores.Command.CreateStore;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Items.Command.CreateItem
{
    internal class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, BaseResponse<int>>
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IRepository<Item> repository, IMapper mapper)
        {
            _itemRepository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<int>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<int>();
            var itemToCreate = _mapper.Map<Item>(request);
            await _itemRepository.AddAsync(itemToCreate);
            if (itemToCreate.Image != null)
            {
                itemToCreate.Image = @$"Images\Items\{itemToCreate.Id}.jpg";
                await _itemRepository.UpdateAsync(itemToCreate);
            }
            response.Result = itemToCreate.Id;
            return response;
        }
    }
}
