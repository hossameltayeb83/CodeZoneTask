using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Application.Features.Stores.Command.UpdateStore;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Items.Command.UpdateItem
{
    internal class UpdateItemCommandHandler :IRequestHandler<UpdateItemCommand,BaseResponse>
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var result = new BaseResponse();
            var itemToUpdate = _mapper.Map<Item>(request);
            result.Success = await _itemRepository.UpdateAsync(itemToUpdate);
            return result;
        }
    }
}
