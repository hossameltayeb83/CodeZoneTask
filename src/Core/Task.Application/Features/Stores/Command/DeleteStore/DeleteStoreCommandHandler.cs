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

namespace Task.Application.Features.Stores.Command.DeleteStore
{
    internal class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, BaseResponse>
    {
        private readonly IRepository<Store> _storeRepository;

        public DeleteStoreCommandHandler(IRepository<Store> storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public async Task<BaseResponse> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();

            var storeToDelete=await _storeRepository.GetByIdAsync(request.Id);
            if (storeToDelete == null)
                throw new NotFoundException("Store Not Found");

            response.Success= await _storeRepository.DeleteAsync(storeToDelete);
            return response;
        }
    }
}
