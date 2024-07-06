using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Features.Stores.Command.UpdateStore;
using Task.Application.Features.Stores.Query.GetPaginatedStores;
using Task.Application.Features.Stores.Query.GetStoreDetails;
using Task.Web.ViewModels;
namespace Task.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StoreController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int page=1,int pageSize=5)
        {
            var response = await _mediator.Send(new GetPaginatedStoresQuery { Page=page,PageSize=pageSize});
            // Todo: manageExeptions
            if (response.Success)
            {
                var result = response.Result;
                var resultVm = _mapper.Map<List<StoreViewModel>>(result.Items);
                // Todo: pass to constructor instead
                var paginatedVm = new PaginatedViewModel<List<StoreViewModel>> { Items=resultVm,
                    HasNextPage=result.HasNextPage,
                    HasPreviousPage=result.HasPreviousPage,
                    Page=result.Page,
                    PageSize=result.PageSize,
                    TotalCount=result.TotalCount,
                    TotalPages=result.TotalPages
                };
                return View(paginatedVm);
            }
            return View();
        }
        public async Task<IActionResult>Edit(int id)
        {
            var response = await _mediator.Send(new GetStoreDetailsQuery {Id=id });
            if (response.Success)
            {
                var storeVm = _mapper.Map<StoreViewModel>(response.Result);
                View(storeVm);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StoreViewModel storeVm,IFormFile image)
        {
            var imgPath= $""
            var response = await _mediator.Send(new UpdateStoreCommand { Id = storeVm.Id,Name=storeVm.Name});
            if (response.Success)
            {
                //var storeVm = _mapper.Map<StoreViewModel>(response.Result);
                View(storeVm);
            }
            return View();
        }
    }
}
