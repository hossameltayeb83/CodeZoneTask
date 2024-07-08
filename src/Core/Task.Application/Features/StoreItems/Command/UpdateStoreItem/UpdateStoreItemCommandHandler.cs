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
using Task.Domain.Enums;

namespace Task.Application.Features.StoreItems.Command.UpdateStoreItem
{
    internal class UpdateStoreItemCommandHandler : IRequestHandler<UpdateStoreItemCommand, BaseResponse>
    {
        private readonly IRepository<StoreItem> _storeItemRepository;
        private readonly IMapper _mapper;

        public UpdateStoreItemCommandHandler(IRepository<StoreItem> storeItemRepository, IMapper mapper)
        {
            _storeItemRepository = storeItemRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateStoreItemCommand request, CancellationToken cancellationToken)
        {
            var response= new BaseResponse();
            var storeItem = await _storeItemRepository.GetByIdAsync(request.ItemId, request.StoreId);
            if (storeItem!=null)
            {
                if (request.Transaction == TransactionType.Purchase)
                {
                    storeItem.Quantity += request.Quantity;
                }
                else 
                {
                    if (storeItem.Quantity - request.Quantity >= 0)
                    {
                        storeItem.Quantity -= request.Quantity;
                    }
                    else
                    {
                        throw new BadRequestException("Balance can't Be negative");
                    }
                }
                response.Success=await _storeItemRepository.UpdateAsync(storeItem);
            }
            else
            {
                var storeItemToCreate = _mapper.Map<StoreItem>(request); 
                response.Success = await _storeItemRepository.AddAsync(storeItemToCreate);
            }
            return response;
        }
    }
}
