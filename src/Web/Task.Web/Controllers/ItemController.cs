using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Features.Items.Command.CreateItem;
using Task.Application.Features.Items.Command.DeleteItem;
using Task.Application.Features.Items.Command.UpdateItem;
using Task.Application.Features.Items.Query.GetItemDetails;
using Task.Application.Features.Items.Query.GetPaginatedItems;
using Task.Application.Responses;
using Task.Web.ViewModels;

namespace Task.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ItemController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            var response = await _mediator.Send(new GetPaginatedItemsQuery { Page = page, PageSize = pageSize });
            
            var result = response.Result;

            var paginatedVm = _mapper.Map<PaginatedViewModel<List<ItemViewModel>>>(result);

            return View(paginatedVm);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(WriteItemViewModel itemVm)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreateItemCommand { Name = itemVm.Name, Image = itemVm.Image });

                return RedirectToAction("Index");
            }
            return View(itemVm);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _mediator.Send(new GetItemDetailsQuery { Id = id });
            
            var itemVm = _mapper.Map<ItemViewModel>(response.Result);
            return View(itemVm);
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(WriteItemViewModel itemVm)
        {
            if(ModelState.IsValid)
            {               
                await _mediator.Send(new UpdateItemCommand { Id = itemVm.Id, Name = itemVm.Name, Image = itemVm.Image });

                return RedirectToAction("Index");
            }
            return View(itemVm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new GetItemDetailsQuery { Id = id });

            var ItemVm = _mapper.Map<ItemViewModel>(response.Result);
            return View(ItemVm);
        }

        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _mediator.Send(new DeleteItemCommand { Id = id });
            
            return RedirectToAction("Index");
        }
    }
}
