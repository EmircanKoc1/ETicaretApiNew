using ETicaretApi.Context;
using ETicaretApi.Entities;
using ETicaretApi.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{ //Controller yazıyoruz ve bu bizin ilgili istekleri yapacağımız api oluyor.
    //Aşağıdaki gibi tanımlıyoruz.

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        //Burada veritabanına sorgu yapmak için bir context nesnesi oluşturuyoruz.
        ETicaretDbContext context = new();

        //Burada api ye Post isteğinde bulunup user ekliyoruz
        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser(User user)
        {
          //Burada gerekli validasyonları yapıyoruz
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
            return Ok("Başarılı");
        }

        //Burada api ye get isteğinde bulunup userları listeliyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await context.Users.ToListAsync();

            return Ok(users);
        }

        //Burada api ye get isteğinde bulunup user ı user id ye göre getiriyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(i => i.UserID == id);
           

            return Ok(user);
        }

        //Burada api ye get isteğinde bulunupuser id ye göre yorumları ve sipariş sayılarını getiriryoruz .
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserByIdCommentandOrderCount(int id)
        {
            var userCommentCount = context.Comments.Count(x => x.UserID == id);
            var userOrderCount = context.Orders.Count(x => x.UserID == id);
            userCountData data = new()
            {
                CommentCount = userCommentCount,
                OrderCount = userOrderCount
            };
            return Ok(data);

        }

        //Burada api ye delete isteğinde bulunup user i user id ye göre siliyoruz.
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserID == id);
            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return Ok(user);

        }
        //Burada api ye put isteğinde bulunup product ı güncelliyoruz.
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
    //Burada model tanımladık count için 
    public class userCountData
    {
        public int CommentCount { get; set; }
        public int OrderCount { get; set; }

    }
}
