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
            
            var result = response.Result;

            var paginatedVm= _mapper.Map<PaginatedViewModel<List<StoreViewModel>>>(result);

            return View(paginatedVm);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(WriteStoreViewModel storeVm)
        {
            BaseResponse<int> response;
            if (ModelState.IsValid)
            {
                if (storeVm.Image != null)
                {
                
                    response = await _mediator.Send(new CreateStoreCommand {  Name = storeVm.Name, Image = "TBD" });
                    var imgPath = @$"Images\Stores\{response.Result}.jpg";
                    var fullPath = @$"wwwroot\{imgPath}";
                    using (FileStream stream = System.IO.File.Create(fullPath))
                    {
                        await storeVm.Image.CopyToAsync(stream);
                    }
                }
                else
                {
                    await _mediator.Send(new CreateStoreCommand {  Name = storeVm.Name });
                }
                return RedirectToAction("Index");
            }
            return View(storeVm);
        }
        public async Task<IActionResult>Edit(int id)
        {
            var response = await _mediator.Send(new GetStoreDetailsQuery {Id=id });

            var storeVm = _mapper.Map<StoreViewModel>(response.Result);
            return View(storeVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WriteStoreViewModel storeVm)
        {
            BaseResponse response;

            if(ModelState.IsValid)
            {
                var imgPath = @$"Images\Stores\{storeVm.Id}.jpg";
                var fullPath= @$"wwwroot\{imgPath}";
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                if (storeVm.Image != null)
                {
                    using (FileStream stream = System.IO.File.Create(fullPath))
                    {
                        await storeVm.Image.CopyToAsync(stream);
                    }
                    response = await _mediator.Send(new UpdateStoreCommand { Id = storeVm.Id, Name = storeVm.Name,Image= imgPath});
                }
                else
                {
                    response = await _mediator.Send(new UpdateStoreCommand { Id = storeVm.Id, Name = storeVm.Name });
                }
                return RedirectToAction("Index");
            }
            return View(storeVm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new GetStoreDetailsQuery { Id = id });
            
            var storeVm = _mapper.Map<StoreViewModel>(response.Result);
            return View(storeVm);
        }
      
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var imgPath = @$"Images\Stores\{id}.jpg";
            var fullPath = @$"wwwroot\{imgPath}";

            await _mediator.Send(new DeleteStoreCommand { Id = id });

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            
            return RedirectToAction("Index");
        }
    }
}
