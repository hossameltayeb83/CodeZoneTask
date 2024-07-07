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
            var storeItem = await _storeItemRepository.GetByIdAsync(request.StoreId, request.ItemId);
            if (storeItem!=null)
            {
                if (request.Transaction == TransactionType.Purchase)
                {
                    storeItem.Quantity += request.Quantity;
                }
                else
                {
                    storeItem.Quantity -= request.Quantity;
                }
                response.Success=await _storeItemRepository.UpdateAsync(storeItem);
            }
            else
            {
                //todo : use mapper
                response.Success = await _storeItemRepository.AddAsync(new StoreItem { StoreId=request.StoreId,ItemId=request.ItemId,Quantity=request.Quantity});
            }
            return response;
        }
    }
}
