using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Task.Domain.Enums;

namespace Task.Web.ViewModels
{
    public class TransactionViewModel
    {
        [Required(ErrorMessage = "*")]
        public int? StoreId { get; set; }
        [Required(ErrorMessage = "*")]
        public int? ItemId { get; set; }
        [Required(ErrorMessage ="*")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Quantity must be a whole number bigger than 0")]
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
