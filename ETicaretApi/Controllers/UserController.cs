using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.Controllers
{
    public class UserController : Controller
    {

        [HttpGet("[action]")]
        public async  Task<IActionResult> GetUsers()
        {




            return Ok();
        }



    }
}
