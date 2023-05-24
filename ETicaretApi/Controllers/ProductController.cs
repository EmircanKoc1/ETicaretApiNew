using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{
    //Controller yazıyoruz ve bu bizin ilgili istekleri yapacağımız api oluyor.
    //Aşağıdaki gibi tanımlıyoruz.

    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        //Burada veritabanına sorgu yapmak için bir context nesnesi oluşturuyoruz.
        ETicaretDbContext context = new();


        //Burada api ye get isteğinde bulunup product ı  product id ye göre getiriyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            Product getProduct = await context.Products.FirstOrDefaultAsync(i => i.ProductID == id);

            return Ok(getProduct);

        }

        //Burada api ye get isteğinde bulunup productları listeliyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await context.Products.ToListAsync();

            return Ok(products);
        }

        //Burada api ye post isteğinde bulunup product ekliyoruz.
        [HttpPost("[action]")]
        public async Task<IActionResult> AddProduct(Product product)
        {

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return Ok(product);

        }
        //Burada api ye put isteğinde bulunup product ı güncelliyoruz.
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            Product getProduct = await context.Products.FirstOrDefaultAsync(i => i.ProductID == product.ProductID);

            getProduct.Title = product.Title;
            getProduct.PreDescription = product.PreDescription;
            getProduct.Description = product.Description;
            getProduct.BrandID = product.BrandID;
            getProduct.CategoryID = product.CategoryID;
            getProduct.ImgSrc = product.ImgSrc;

            await context.SaveChangesAsync();
            return Ok(getProduct);

        }

        //Burada api ye delete isteğinde bulunup productı id ye göre siliyoruz
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            var getProduct = await context.Products.FirstOrDefaultAsync(i => i.ProductID == id);
            context.Products.Remove(getProduct);
            context.SaveChanges();
            return Ok(getProduct);
        }
        //Burada api ye get isteğinde bulunup productları brand id  ye göre listeliyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsByBrandID(int id)
        {
            var products = await context.Products.Where(p=>p.BrandID == id).ToListAsync();

            return Ok(products);
        }
        //Burada api ye get isteğinde bulunup productları  category id ye göre listeliyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsByCategoryID(int id)
        {
            var products = await context.Products.Where(p => p.CategoryID == id).ToListAsync();

            return Ok(products);
        }

        //Burada api ye get isteğinde bulunup productları category ve brand id ye göre listeliyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsByBrandIDandCategoryID(int brandID,int categoryID)
        {
            var products = await context.Products.Where(p => p.BrandID == brandID && p.CategoryID == categoryID ).ToListAsync();

            return Ok(products);
        }

        //Burada api ye get isteğinde bulunup ilk 12 productları listeliyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsFirst12()
        {
            var products = await context.Products.Take(12).ToListAsync();
           

            return Ok(products);
        }

    }
}
