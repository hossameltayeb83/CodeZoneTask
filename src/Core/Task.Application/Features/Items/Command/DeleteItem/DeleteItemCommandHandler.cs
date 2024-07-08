using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Infrastructure;
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
        private readonly IImageService _imageService;

        public DeleteItemCommandHandler(IRepository<Item> itemRepository,IImageService imageService)
        {
            _itemRepository = itemRepository;
            _imageService = imageService;
        }
        public async Task<BaseResponse> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var itemToDelete = await _itemRepository.GetByIdAsync(request.Id);
            if (itemToDelete == null)
                throw new NotFoundException("Item Not Found");

            var imgPath = @$"Images\Items\{itemToDelete.Id}.jpg";
            _imageService.DeleteImage(imgPath);

            response.Success = await _itemRepository.DeleteAsync(itemToDelete);            
            return response;
        }
    }
}
