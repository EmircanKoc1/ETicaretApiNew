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
        ETicaretDbContext context = new();


        [HttpGet("[action]")]
        public async Task<IActionResult> GetBanners()
        {
            var banner = await context.Banners.ToListAsync();
            return Ok(banner);

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddBanner(Banners banner)
        {
            await context.Banners.AddAsync(banner);
            var state = await context.SaveChangesAsync();
            return Ok(state);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBanner(Banners banner)
        {
            Banners getBanner = await context.Banners.FirstOrDefaultAsync(i => i.BannersID == banner.BannersID);
            getBanner.ImgSrc = banner.ImgSrc;
            var state = await context.SaveChangesAsync();
            return Ok(state);

        }

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
