using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.Controllers
{
    public class BannersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
