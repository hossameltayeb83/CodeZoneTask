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
        public async Task<IActionResult> Index([FromQuery]GetPaginatedStoresQuery query)
        {
            var response = await _mediator.Send(query);
            if (response.Success)
            {
                var result = response.Result;
                var resultVm = _mapper.Map<List<StoreViewModel>>(result.Items);
                var paginatedVm = _mapper.Map<PaginatedViewModel<StoreViewModel>>(result.Items);
                return View(paginatedVm);
            }
            return View();
        }
    }
}
