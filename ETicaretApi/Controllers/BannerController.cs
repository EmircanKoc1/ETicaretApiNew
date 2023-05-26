
using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{  //Controller yazıyoruz ve bu bizin ilgili istekleri yapacağımız api oluyor.
    //Aşağıdaki gibi tanımlıyoruz.

    [ApiController]
    [Route("[controller]")]
    public class BannerController : Controller
    {
        //Burada veritabanına sorgu yapmak için bir context nesnesi oluşturuyoruz.
        ETicaretDbContext context = new();

        //Burada api ye get isteğinde bulunup banner i alıyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBanner()
        {
            var banner =  await context.Banner.ToListAsync();
            return Ok(banner);

        }

        //Burada api ye post isteğinde bulunup banner i ekliyoruz.
        [HttpPost("[action]")]
        public async Task<IActionResult> AddBanner(Banner banner)
        {
            await context.Banner.AddAsync(banner);
            var state =  await context.SaveChangesAsync(); 
            return Ok(state);

        }

        //Burada api ye put isteğinde bulunup banner i güncelliyoruz.
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBanner(Banner banner)
        {
            Banner getBanner = await context.Banner.FirstOrDefaultAsync(i => i.BannerID == banner.BannerID);
            getBanner.ImgSrc = banner.ImgSrc;
            var state = await context.SaveChangesAsync();
            return Ok(state);

        }

        //Burada api ye delete isteğinde bulunup banner i siliyoruz.
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            Banner getBanner = await context.Banner.FirstOrDefaultAsync(i => i.BannerID == id);
            context.Remove(getBanner);
            var state = await context.SaveChangesAsync();
            return Ok(state);

        }




    }

}
