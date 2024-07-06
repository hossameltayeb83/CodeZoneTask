using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Application.Features.Stores.Query;
using Task.Application.Responses;
using Task.Domain.Entities;

namespace Task.Application.Features.Stores.Command.CreateStore
{
    internal class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand, BaseResponse<int>>
    {
        private readonly IRepository<Store> _storeRepository;
        private readonly IMapper _mapper;

        public CreateStoreCommandHandler(IRepository<Store> repository,IMapper mapper)
        {
            _storeRepository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<int>> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<int>();
            var storeToCreate= _mapper.Map<Store>(request);
            await _storeRepository.AddAsync(storeToCreate);
            if (storeToCreate.Image != null)
            {
                storeToCreate.Image= @$"Images\Stores\{storeToCreate.Id}.jpg";
                await _storeRepository.UpdateAsync(storeToCreate);
            }
            response.Result=storeToCreate.Id;
            return response;
        }
    }
}
