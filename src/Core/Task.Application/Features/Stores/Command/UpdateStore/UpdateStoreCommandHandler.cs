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
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Stores.Command.UpdateStore
{
    internal class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, BaseResponse>
    {
        private readonly IRepository<Store> _storeRepository;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public UpdateStoreCommandHandler(IRepository<Store> storeRepository,IMapper mapper,IImageService imageService)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task<BaseResponse> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var result = new BaseResponse();

            if (request.Name.Length < 3 || request.Name.Length > 100)
                throw new BadRequestException("Store name must be between 3 and 100 characters");

            var storeToUpdate = _mapper.Map<Store>(request);

            var imgPath = @$"Images\Stores\{storeToUpdate.Id}.jpg";
            if (request.Image != null)
            {
                storeToUpdate.Image = imgPath;
            }
            else
            {
                storeToUpdate.Image = null;
            }
            await _imageService.UpdateImageAsync(request.Image, imgPath);

            result.Success = await _storeRepository.UpdateAsync(storeToUpdate);
            return result;
        }
    }
}
