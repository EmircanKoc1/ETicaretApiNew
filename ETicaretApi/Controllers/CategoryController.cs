using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        //Controller yazıyoruz ve bu bizin ilgili istekleri yapacağımız api oluyor.
        //Aşağıdaki gibi tanımlıyoruz.

        //Burada veritabanına sorgu yapmak için bir context nesnesi oluşturuyoruz.
        ETicaretDbContext context = new();

        //Burada api ye get isteğinde bulunup categoryi id ye göre getiriyoruz
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryByID(int id)
        {
            Category getCategory = await context.Categories.FirstOrDefaultAsync(i => i.CategoryID == id);
            return Ok(getCategory);
        }

        //Burada api ye get isteğinde bulunup categoryleri listeliyoruz
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await context.Categories.ToListAsync();
            return Ok(categories);
        }

        //Burada api ye post isteğinde bulunup category ekliyoruz
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategory(Category category)
        {   
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return Ok(category);

        }

        //Burada api ye put isteğinde bulunup categoryi güncelliyoruz
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            Category getCategory = await context.Categories.FirstOrDefaultAsync(i => i.CategoryID == category.CategoryID);

            getCategory.ImgSrc = category.ImgSrc;
            getCategory.Name = category.Name;
            
            await context.SaveChangesAsync();

            return Ok(getCategory);
        }

        //Burada api ye delete isteğinde bulunup categoryi id ye göre siliyoruz
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCategoryByID(int id)
        {
            Category category = await context.Categories.FirstOrDefaultAsync(i => i.CategoryID == id);
            context.Remove(category);
            await context.SaveChangesAsync();

            return Ok(category);
        }



    }
}
