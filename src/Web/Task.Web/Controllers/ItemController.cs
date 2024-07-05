using Microsoft.AspNetCore.Mvc;

namespace Task.Web.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
