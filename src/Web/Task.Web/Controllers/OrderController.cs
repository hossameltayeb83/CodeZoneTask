using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Features.Items.Query.GetAllItems;
using Task.Application.Features.Stores.Query.GetAllStores;
using Task.Application.Features.Stores.Query.GetStoreItemBalance;
using Task.Web.ViewModels;

namespace Task.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Purchase(int? storeId,int? itemId)
        {
            var purchaseVm = new PurchaseViewModel();
            if (storeId.HasValue)
                purchaseVm.StoreId = storeId.Value;
            if(itemId.HasValue)
                purchaseVm.ItemId = itemId.Value;
            var storesResponse = await _mediator.Send(new GetAllStoresQuery());
            var itemsResponse = await _mediator.Send(new GetAllItemsQuery());
            purchaseVm.Stores= _mapper.Map<List<StoreViewModel>>(storesResponse.Result);
            purchaseVm.Items= _mapper.Map<List<ItemViewModel>>(itemsResponse.Result);
            return View(purchaseVm);
        }
        [HttpPost]
        public IActionResult Purchase(PurchaseViewModel purchaseViewModel)
        {
            if (ModelState.IsValid)
            {
                //var response= _mediator.Send(new UpdateStoreItem );
                return RedirectToAction("Purchase", new {storeId=purchaseViewModel.StoreId,itemId=purchaseViewModel.ItemId});
            }
            return View(purchaseViewModel);
        }
        public async Task<IActionResult> Balance(int storeId,int itemId)
        {
            var response = await _mediator.Send(new GetStoreItemBalanceQuery { StoreId=storeId,ItemId=itemId});
            return Ok(response.Result);
        }
    }
}
