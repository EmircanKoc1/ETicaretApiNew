using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ETicaretApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SearchController : Controller
    {
        ETicaretDbContext context = new();

        [HttpGet("[action]")]
        public async Task<IActionResult> Search(string words)
        {
            Category  result = await context.Categories.FirstOrDefaultAsync(e => e.Name.Contains(words));
            
            if (result == null)
            {
                var result2 = await context.Brands.FirstOrDefaultAsync(e => e.Name.Contains(words));
                var products2 = await context.Products.Where(x => x.BrandID == result2.BrandID).ToListAsync();
                return Ok(products2);
            }
            else
            {
                var products = await context.Products.Where(x => x.CategoryID == result.CategoryID).ToListAsync();
                return Ok(products);
            }
           

        }
    }



}

