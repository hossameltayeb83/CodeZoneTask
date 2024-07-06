using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Features.Stores.Query;
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
            if (response.Success)
            {
                var result = response.Result;
                var resultVm = _mapper.Map<List<StoreViewModel>>(result.Items);
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
    }
}
