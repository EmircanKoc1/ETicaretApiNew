using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BannersController : Controller
    {
        //Controller yazıyoruz ve bu bizin ilgili istekleri yapacağımız api oluyor.
        //Aşağıdaki gibi tanımlıyoruz.

        //Burada veritabanına sorgu yapmak için bir context nesnesi oluşturuyoruz.
        ETicaretDbContext context = new();


        //Burada api ye get isteğinde bulunup bannersi listeliyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBanners()
        {
            var banner = await context.Banners.ToListAsync();
            return Ok(banner);

        }


        //Burada api ye post isteğinde bulunup banners ekliyoruz.
        [HttpPost("[action]")]
        public async Task<IActionResult> AddBanner(Banners banner)
        {
            await context.Banners.AddAsync(banner);
            var state = await context.SaveChangesAsync();
            return Ok(state);

        }

        //Burada api ye Put isteğinde bulunup bannersi güncelliyoruz.
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBanner(Banners banner)
        {
            Banners getBanner = await context.Banners.FirstOrDefaultAsync(i => i.BannersID == banner.BannersID);
            getBanner.ImgSrc = banner.ImgSrc;
            var state = await context.SaveChangesAsync();
            return Ok(state);

        }

        //Burada api ye delete isteğinde bulunup bannersi siliyoruz.
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            Banners getBanner = await context.Banners.FirstOrDefaultAsync(i => i.BannersID == id);
            context.Remove(getBanner);
            var state = await context.SaveChangesAsync();
            return Ok(state);

        }



    }
}
