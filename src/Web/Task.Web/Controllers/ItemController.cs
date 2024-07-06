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
            // Todo: manageExeptions
            if (response.Success)
            {
                var result = response.Result;
                var resultVm = _mapper.Map<List<ItemViewModel>>(result.Items);
                // Todo: pass to constructor instead
                var paginatedVm = new PaginatedViewModel<List<ItemViewModel>>
                {
                    Items = resultVm,
                    HasNextPage = result.HasNextPage,
                    HasPreviousPage = result.HasPreviousPage,
                    Page = result.Page,
                    PageSize = result.PageSize,
                    TotalCount = result.TotalCount,
                    TotalPages = result.TotalPages
                };
                return View(paginatedVm);
            }
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(IFormFile image, ItemViewModel itemVm)
        {
            BaseResponse<int> response;
            if (image != null)
            {

                response = await _mediator.Send(new CreateItemCommand { Name = itemVm.Name, Image = "TBD" });
                if (response.Success)
                {
                    var imgPath = @$"Images\Items\{response.Result}.jpg";
                    var fullPath = @$"wwwroot\{imgPath}";
                    using (FileStream stream = System.IO.File.Create(fullPath))
                    {
                        await image.CopyToAsync(stream);
                    }
                }
            }
            else
            {
                response = await _mediator.Send(new CreateItemCommand { Name = itemVm.Name });
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _mediator.Send(new GetItemDetailsQuery { Id = id });
            if (response.Success)
            {
                var itemVm = _mapper.Map<ItemViewModel>(response.Result);
                View(itemVm);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile image, ItemViewModel itemVm)
        {
            BaseResponse response;
            if (image != null)
            {
                var imgPath = @$"Images\Items\{itemVm.Id}.jpg";
                var fullPath = @$"wwwroot\{imgPath}";
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                using (FileStream stream = System.IO.File.Create(fullPath))
                {
                    await image.CopyToAsync(stream);
                }
                response = await _mediator.Send(new UpdateItemCommand { Id = itemVm.Id, Name = itemVm.Name, Image = imgPath });
            }
            else
            {
                response = await _mediator.Send(new UpdateItemCommand { Id = itemVm.Id, Name = itemVm.Name });
            }
            //Todo : manage failure
            //if (response.Success)
            //{
            //    //var storeVm = _mapper.Map<StoreViewModel>(response.Result);
            //    View(storeVm);
            //}
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new GetItemDetailsQuery { Id = id });
            if (response.Success)
            {
                var ItemVm = _mapper.Map<ItemViewModel>(response.Result);
                View(ItemVm);
            }
            return View();
        }

        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var imgPath = @$"Images\Items\{id}.jpg";
            var fullPath = @$"wwwroot\{imgPath}";
            var response = await _mediator.Send(new DeleteItemCommand { Id = id });
            //Todo : manage failure
            if (response.Success)
            {
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
