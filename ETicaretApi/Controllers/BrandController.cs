using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        ETicaretDbContext context = new();

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrandByID(int id)
        {
            Brand getBrand = await context.Brands.FirstOrDefaultAsync(i => i.BrandID == id);   
            return Ok(getBrand);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrands()
        {
            var getBrands = await context.Brands.ToListAsync();
            return Ok(getBrands);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddBrand(Brand brand)
        {
           await context.Brands.AddAsync(brand);
           await context.SaveChangesAsync();
           return Ok(brand);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBrand(Brand brand)
        {
            Brand getBrand = await context.Brands.FirstOrDefaultAsync(i => i.BrandID == brand.BrandID);



            getBrand.Name = brand.Name;
            getBrand.ImgSrc = brand.ImgSrc;
           
            await context.SaveChangesAsync();
            return Ok(getBrand);

        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteByID(int id)
        {
            Brand getBrand = await context.Brands.FirstOrDefaultAsync(i => i.BrandID == id);
            context.Remove(getBrand);
            await context.SaveChangesAsync();
            return Ok(getBrand);
        }



    }
}
