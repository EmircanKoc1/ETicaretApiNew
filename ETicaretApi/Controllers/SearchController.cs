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
    public class SearchController : Controller
    {
        //Burada Search isminde bir api yazdım Basit Arama işlemleri için 
        //gönderilen veriyi alarak uygun ürünleri listeleyecek

        //Burada veritabanına sorgu yapmak için bir context nesnesi oluşturuyoruz.
        ETicaretDbContext context = new();

        //Burada api ye get isteğinde bulunup worde geçen kelimeye göre ürün listeliyoruz.
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

