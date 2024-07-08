using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Features.Items.Query.GetAllItems;
using Task.Application.Features.Stores.Query.GetAllStores;
using Task.Application.Features.StoreItems.Query.GetStoreItemBalance;
using Task.Web.ViewModels;
using Task.Application.Features.StoreItems.Command.UpdateStoreItem;
using Task.Domain.Enums;

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
        public async Task<IActionResult> Transaction(int? storeId,int? itemId)
        {
            var transactionVm = new TransactionViewModel();

            if (storeId.HasValue)
                transactionVm.StoreId = storeId.Value;
            if(itemId.HasValue)
                transactionVm.ItemId = itemId.Value;

            var storesResponse = await _mediator.Send(new GetAllStoresQuery());
            var itemsResponse = await _mediator.Send(new GetAllItemsQuery());

            transactionVm.Stores= _mapper.Map<List<StoreViewModel>>(storesResponse.Result);
            transactionVm.Items= _mapper.Map<List<ItemViewModel>>(itemsResponse.Result);
            return View(transactionVm);
        }
        [HttpPost]
        public async Task<IActionResult> Transaction(TransactionViewModel transactionViewModel)
        {
            if (ModelState.IsValid)
            {
                var response= await _mediator.Send(new UpdateStoreItemCommand { StoreId=transactionViewModel.StoreId!.Value,
                ItemId=transactionViewModel.ItemId!.Value,
                Quantity=transactionViewModel.Quantity,
                Transaction=transactionViewModel.Transaction} );
            }
            return RedirectToAction("Transaction", new {storeId=transactionViewModel.StoreId,itemId=transactionViewModel.ItemId});
        }
        public async Task<IActionResult> Balance(int storeId,int itemId)
        {
            var response = await _mediator.Send(new GetStoreItemBalanceQuery { StoreId=storeId,ItemId=itemId});
            return Ok(response.Result);
        }
        public async Task<IActionResult> CheckBalance(int storeId, int itemId,int quantity,TransactionType transaction)
        {
            bool valid = true;
            if (transaction == TransactionType.Sell)
            {
                var response = await _mediator.Send(new GetStoreItemBalanceQuery { StoreId = storeId, ItemId = itemId });
                if(response.Result-quantity<0)
                {
                    valid=false;
                }
            }
            return Json(valid);
        }
    }
}
