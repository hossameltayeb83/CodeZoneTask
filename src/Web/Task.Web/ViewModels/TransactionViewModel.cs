using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Task.Domain.Enums;

namespace Task.Web.ViewModels
{
    public class TransactionViewModel
    {
        public int? StoreId { get; set; }
        public int? ItemId { get; set; }
        [Required(ErrorMessage ="*")]
        [Range(1, int.MaxValue,ErrorMessage ="Quantity Must Be Greater Than 1")]
        [Remote("CheckBalance",
            "Order",
            AdditionalFields ="StoreId,ItemId,Quantity,Transaction",
            ErrorMessage ="Sell Quantity can't be Higher Than Balance")]
        public int Quantity { get; set; }
        
        public List<StoreViewModel>? Stores { get; set; }
        public List<ItemViewModel>? Items { get; set; }
        public TransactionType Transaction { get; set; }
    }

}
