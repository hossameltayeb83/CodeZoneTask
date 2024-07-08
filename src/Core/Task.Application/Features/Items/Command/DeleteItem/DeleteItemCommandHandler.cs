using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Application.Exceptions;
using Task.Application.Features.Stores.Command.DeleteStore;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Items.Command.DeleteItem
{
    internal class DeleteItemCommandHandler :IRequestHandler<DeleteItemCommand,BaseResponse>
    {
        private readonly IRepository<Item> _itemRepository;

        public DeleteItemCommandHandler(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<BaseResponse> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var itemToDelete = await _itemRepository.GetByIdAsync(request.Id);
            if (itemToDelete == null)
                throw new NotFoundException("Item Not Found");

            response.Success = await _itemRepository.DeleteAsync(itemToDelete);            
            return response;
        }
    }
}
