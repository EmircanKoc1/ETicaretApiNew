using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {

        ETicaretDbContext context = new();


        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            Product getProduct = await context.Products.FirstOrDefaultAsync(i => i.ProductID == id);

            return Ok(getProduct);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProduct(Product product)
        {

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return Ok(product);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            Product getProduct = await  context.Products.FirstOrDefaultAsync(i=>i.ProductID == product.ProductID);
            getProduct = new()
            {
                Title = product.Title,
                PreDescription = product.PreDescription,
                Description = product.Description,
                BrandID = product.BrandID,
                CategoryID = product.CategoryID,
                ImgSrc = product.ImgSrc
            };
            await context.SaveChangesAsync();
            return Ok(getProduct);

        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var getProduct = await context.Products.FirstOrDefaultAsync(i => i.ProductID == id);
            context.Products.Remove(getProduct);
            context.SaveChanges();
            return Ok(getProduct);
        }







    }
}
