using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Infrastructure;
using Task.Application.Contracts.Persistence;
using Task.Application.Exceptions;
using Task.Application.Features.Stores.Command.UpdateStore;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Items.Command.UpdateItem
{
    internal class UpdateItemCommandHandler :IRequestHandler<UpdateItemCommand,BaseResponse>
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public UpdateItemCommandHandler(IRepository<Item> itemRepository, IMapper mapper,IImageService imageService)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task<BaseResponse> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var result = new BaseResponse();

            if (request.Name.Length < 3 || request.Name.Length > 100)
                throw new BadRequestException("Item name must be between 3 and 100 characters");

            var itemToUpdate = _mapper.Map<Item>(request);

            var imgPath = @$"Images\Items\{itemToUpdate.Id}.jpg";
            if (request.Image != null)
            {
                itemToUpdate.Image = imgPath;
            }
            else
            {
                itemToUpdate.Image = null;
            }
            await _imageService.UpdateImageAsync(request.Image, imgPath);

            result.Success = await _itemRepository.UpdateAsync(itemToUpdate);
            return result;
        }
    }
}
