using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
