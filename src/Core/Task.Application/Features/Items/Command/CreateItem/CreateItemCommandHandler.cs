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
using Task.Application.Features.Stores.Command.CreateStore;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Items.Command.CreateItem
{
    internal class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, BaseResponse<int>>
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public CreateItemCommandHandler(IRepository<Item> repository, IMapper mapper,IImageService imageService)
        {
            _itemRepository = repository;
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task<BaseResponse<int>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<int>();

            if(request.Name.Length<3 || request.Name.Length > 100)
                throw new BadRequestException("Item name must be between 3 and 100 characters");

            var itemToCreate = _mapper.Map<Item>(request);
            await _itemRepository.AddAsync(itemToCreate);

            if (request.Image != null)
            {
                var imgPath = @$"Images\Items\{itemToCreate.Id}.jpg";
                itemToCreate.Image = imgPath;
                await _itemRepository.UpdateAsync(itemToCreate);
                await _imageService.SaveImageAsync(request.Image, imgPath);
            }

            response.Result = itemToCreate.Id;
            return response;
        }
    }
}
