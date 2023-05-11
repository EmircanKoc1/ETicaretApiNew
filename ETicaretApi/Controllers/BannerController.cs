using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BannerController : Controller
    {
        ETicaretDbContext context = new();

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBanner()
        {
            var banner =  await context.Banner.ToListAsync();
            return Ok(banner);

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddBanner(Banner banner)
        {
            await context.Banner.AddAsync(banner);
            var state =  await context.SaveChangesAsync(); 
            return Ok(state);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBanner(Banner banner)
        {
            Banner getBanner = await context.Banner.FirstOrDefaultAsync(i => i.BannerID == banner.BannerID);
            getBanner.ImgSrc = banner.ImgSrc;
            var state = await context.SaveChangesAsync();
            return Ok(state);

        }

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
