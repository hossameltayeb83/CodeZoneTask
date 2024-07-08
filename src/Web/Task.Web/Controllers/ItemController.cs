using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Features.Items.Command.CreateItem;
using Task.Application.Features.Items.Command.DeleteItem;
using Task.Application.Features.Items.Command.UpdateItem;
using Task.Application.Features.Items.Query.GetItemDetails;
using Task.Application.Features.Items.Query.GetPaginatedItems;
using Task.Application.Features.Stores.Command.CreateStore;
using Task.Application.Features.Stores.Command.DeleteStore;
using Task.Application.Features.Stores.Command.UpdateStore;
using Task.Application.Features.Stores.Query.GetPaginatedStores;
using Task.Application.Features.Stores.Query.GetStoreDetails;
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
            BaseResponse<int> response;
            if (ModelState.IsValid)
            {
                if (itemVm.Image != null)
                {

                    response = await _mediator.Send(new CreateItemCommand { Name = itemVm.Name, Image = "TBD" });
                    var imgPath = @$"Images\Items\{response.Result}.jpg";
                    var fullPath = @$"wwwroot\{imgPath}";
                    using (FileStream stream = System.IO.File.Create(fullPath))
                    {
                        await itemVm.Image.CopyToAsync(stream);
                    }
                
                }
                else
                {
                    await _mediator.Send(new CreateItemCommand { Name = itemVm.Name });
                }
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
            BaseResponse response;

            if(ModelState.IsValid)
            {
                var imgPath = @$"Images\Items\{itemVm.Id}.jpg";
                var fullPath = @$"wwwroot\{imgPath}";
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                if (itemVm.Image != null)
                {
                    using (FileStream stream = System.IO.File.Create(fullPath))
                    {
                        await itemVm.Image.CopyToAsync(stream);
                    }
                    response = await _mediator.Send(new UpdateItemCommand { Id = itemVm.Id, Name = itemVm.Name, Image = imgPath });
                }
                else
                {
                    response = await _mediator.Send(new UpdateItemCommand { Id = itemVm.Id, Name = itemVm.Name });
                }
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
            var imgPath = @$"Images\Items\{id}.jpg";
            var fullPath = @$"wwwroot\{imgPath}";

            await _mediator.Send(new DeleteItemCommand { Id = id });
            
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            
            return RedirectToAction("Index");
        }
    }
}
