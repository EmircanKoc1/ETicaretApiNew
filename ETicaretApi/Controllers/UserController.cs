using ETicaretApi.Entities;
using ETicaretApi.Validators;
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
            var validator = new UserValidator();
            var validationResult = validator.Validate(user);

            if (validationResult.IsValid)
            {
                return Ok("işlem başarılı");
            }
            else
            {
                return Ok(validationResult);
            }
        }



    }
}
