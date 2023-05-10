using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
