using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Infrastructure;
using Task.Application.Contracts.Persistence;
using Task.Application.Exceptions;
using Task.Application.Features.Stores.Query;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Stores.Command.CreateStore
{
    internal class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, BaseResponse<int>>
    {
        private readonly IRepository<Store> _storeRepository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public CreateStoreCommandHandler(IRepository<Store> repository,IMapper mapper,IImageService imageService)
        {
            _storeRepository = repository;
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task<BaseResponse<int>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<int>();

            if (request.Name.Length < 3 || request.Name.Length > 100)
                throw new BadRequestException("Store name must be between 3 and 100 characters");

            var storeToCreate= _mapper.Map<Store>(request);
            await _storeRepository.AddAsync(storeToCreate);

            if (request.Image != null)
            {
                var imgPath = @$"Images\Stores\{storeToCreate.Id}.jpg";
                storeToCreate.Image = imgPath;
                await _storeRepository.UpdateAsync(storeToCreate);
                await _imageService.SaveImageAsync(request.Image, imgPath);
            }

            response.Result=storeToCreate.Id;
            return response;
        }
    }
}
