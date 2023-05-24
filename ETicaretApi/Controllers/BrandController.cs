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
        //Controller yazıyoruz ve bu bizin ilgili istekleri yapacağımız api oluyor.
        //Aşağıdaki gibi tanımlıyoruz.

        //Burada veritabanına sorgu yapmak için bir context nesnesi oluşturuyoruz.
        ETicaretDbContext context = new();

        //Burada api ye get isteğinde bulunup marka yı id ye göre getiriyoruz
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrandByID(int id)
        {
            Brand getBrand = await context.Brands.FirstOrDefaultAsync(i => i.BrandID == id);   
            return Ok(getBrand);
        }

        //Burada api ye get isteğinde bulunup markaları listeliyoruz
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrands()
        {
            var getBrands = await context.Brands.ToListAsync();
            return Ok(getBrands);
        }

        //Burada api ye post isteğinde bulunup marka ekliyoruz
        [HttpPost("[action]")]
        public async Task<IActionResult> AddBrand(Brand brand)
        {
           await context.Brands.AddAsync(brand);
           await context.SaveChangesAsync();
           return Ok(brand);

        }

        //Burada api ye put isteğinde bulunup markayı güncelliyoruz
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBrand(Brand brand)
        {
            Brand getBrand = await context.Brands.FirstOrDefaultAsync(i => i.BrandID == brand.BrandID);



            getBrand.Name = brand.Name;
            getBrand.ImgSrc = brand.ImgSrc;
           
            await context.SaveChangesAsync();
            return Ok(getBrand);

        }

        //Burada api ye delete isteğinde bulunup markayı siliyoruz
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
