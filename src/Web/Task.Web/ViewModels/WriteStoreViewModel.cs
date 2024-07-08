using System.ComponentModel.DataAnnotations;

namespace Task.Web.ViewModels
{
    public class WriteStoreViewModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Store name must be between 3 and 100 characters")]
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
    }
}
