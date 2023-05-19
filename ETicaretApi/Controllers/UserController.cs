using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser(User user)
        {

            var userx = user;


            return Ok(userx);
        }



    }
}
