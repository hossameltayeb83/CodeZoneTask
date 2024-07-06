using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Features.Stores.Command.CreateStore;
using Task.Application.Features.Stores.Command.DeleteStore;
using Task.Application.Features.Stores.Command.UpdateStore;
using Task.Application.Features.Stores.Query.GetPaginatedStores;
using Task.Application.Features.Stores.Query.GetStoreDetails;
using Task.Application.Responses;
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
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(IFormFile image, StoreViewModel storeVm)
        {
            BaseResponse<int> response;
            if (image != null)
            {
                
                response = await _mediator.Send(new CreateStoreCommand {  Name = storeVm.Name, Image = "TBD" });
                if (response.Success)
                {
                    var imgPath = @$"Images\Stores\{response.Result}.jpg";
                    var fullPath = @$"wwwroot\{imgPath}";
                    using (FileStream stream = System.IO.File.Create(fullPath))
                    {
                        await image.CopyToAsync(stream);
                    }
                }
            }
            else
            {
                response = await _mediator.Send(new CreateStoreCommand {  Name = storeVm.Name });
            }
            return RedirectToAction("Index");
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
        public async Task<IActionResult> Edit(IFormFile image, StoreViewModel storeVm)
        {
            BaseResponse response;
            if (image != null)
            {
                var imgPath = @$"Images\Stores\{storeVm.Id}.jpg";
                var fullPath= @$"wwwroot\{imgPath}";
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                using (FileStream stream = System.IO.File.Create(fullPath))
                {
                    await image.CopyToAsync(stream);
                }
                response = await _mediator.Send(new UpdateStoreCommand { Id = storeVm.Id, Name = storeVm.Name,Image= imgPath});
            }
            else
            {
                response = await _mediator.Send(new UpdateStoreCommand { Id = storeVm.Id, Name = storeVm.Name });
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
            var response = await _mediator.Send(new GetStoreDetailsQuery { Id = id });
            if (response.Success)
            {
                var storeVm = _mapper.Map<StoreViewModel>(response.Result);
                View(storeVm);
            }
            return View();
        }
      
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var imgPath = @$"Images\Stores\{id}.jpg";
            var fullPath = @$"wwwroot\{imgPath}";
            var response = await _mediator.Send(new DeleteStoreCommand { Id = id });
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
