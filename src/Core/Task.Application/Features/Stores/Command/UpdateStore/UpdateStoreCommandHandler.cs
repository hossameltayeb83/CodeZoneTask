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

namespace Task.Application.Features.Stores.Command.UpdateStore
{
    internal class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, BaseResponse>
    {
        private readonly IRepository<Store> _storeRepository;
        private readonly IMapper _mapper;

        public UpdateStoreCommandHandler(IRepository<Store> storeRepository,IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var result = new BaseResponse();

            if (request.Name.Length < 3 || request.Name.Length > 100)
                throw new BadRequestException("Store name must be between 3 and 100 characters");

            var storeToUpdate = _mapper.Map<Store>(request);

            result.Success = await _storeRepository.UpdateAsync(storeToUpdate);
            return result;
        }
    }
}
