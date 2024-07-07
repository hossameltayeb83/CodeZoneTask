using System.ComponentModel.DataAnnotations;

namespace Task.Web.ViewModels
{
    public class PurchaseViewModel
    {
        public int? StoreId { get; set; }
        public int? ItemId { get; set; }
        [Required]
        [Range(1, int.MaxValue,ErrorMessage ="Quantity Must Be Greater Than 1")]
        public int Quantity { get; set; }
        public List<StoreViewModel> Stores { get; set; }
        public List<ItemViewModel> Items { get; set; }
    }
}
