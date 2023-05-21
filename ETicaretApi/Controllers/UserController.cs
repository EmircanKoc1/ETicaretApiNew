using ETicaretApi.Context;
using ETicaretApi.Entities;
using ETicaretApi.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        ETicaretDbContext context = new();

        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser(User user)
        {
          
            var validator = new UserValidator();
            var validationResult = validator.Validate(user);

            if (validationResult.IsValid)
            {
                
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();


                return Ok(user);
            }
            else
            {
                return Ok(validationResult);
            }
            return Ok("ddddddddddddddddddd");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await context.Users.ToListAsync();

            return Ok(users);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserID == id);
            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return Ok(user);

        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var getUser = await context.Users.FirstOrDefaultAsync(i=>i.UserID == user.UserID);
            getUser.Name = user.Name;
            getUser.SurName = user.SurName;
            getUser.UserName = user.UserName;
            getUser.Email = user.Email;
            getUser.PhoneNumber = user.PhoneNumber;
            getUser.Adress = user.Adress;
            getUser.ImgSrc = user.ImgSrc;
            getUser.Password = user.Password;

            await context.SaveChangesAsync();

            return Ok(getUser);
        }


    }
}
