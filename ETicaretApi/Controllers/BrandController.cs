using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
