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
        ETicaretDbContext context = new();

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryByID(int id)
        {
            Category getCategory = await context.Categories.FirstOrDefaultAsync(i => i.CategoryID == id);
            return Ok(getCategory);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await context.Categories.ToListAsync();
            return Ok(categories);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategory(Category category)
        {   
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return Ok(category);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            Category getCategory = await context.Categories.FirstOrDefaultAsync(i => i.CategoryID == category.CategoryID);

            getCategory.ImgSrc = category.ImgSrc;
            getCategory.Name = category.Name;
            
            await context.SaveChangesAsync();

            return Ok(getCategory);
        }

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
