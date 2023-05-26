using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BasketProductController : Controller
    {
        //Controller yazıyoruz ve bu bizin ilgili istekleri yapacağımız api oluyor.
        //Aşağıdaki gibi tanımlıyoruz.

        //Burada veritabanına sorgu yapmak için bir context nesnesi oluşturuyoruz.
        ETicaretDbContext context = new();

        //Burada api ye get isteğinde bulunup sepetteki ürünleri listeliyoruz
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasketProducts(int userId)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i=>i.UserID == userId);
            var basketItems = await context.BasketProducts.Where(i=>i.BasketID == basket.BasketID).ToListAsync();
            var products = new List<Product>();

            foreach (var item in basketItems)
            {
                var product = await context.Products.FirstOrDefaultAsync(i => i.ProductID == item.ProductID);
             
                products.Add(product);
            }


            return Ok(products);
        }
        //Burada api ye post isteğinde bulunup sepete ürün ekliyoruz.
        [HttpPost("[action]")]
        public async Task<IActionResult> AddProductFromBasket(int userId , int productId)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i => i.UserID == userId);
            var product = await context.Products.FirstOrDefaultAsync(i=>i.ProductID == productId);
            BasketProduct basketProduct = new()
            {  
                BasketID = basket.BasketID,
                ProductID = product.ProductID,
                Quantity = 1,
                Price = product.Price 
            };
            await context.BasketProducts.AddAsync(basketProduct);
            await context.SaveChangesAsync();

            return Ok(basketProduct);
        }

        //Burada api ye delete isteğinde bulunup sepetteki ürünü siliyoruz
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteProductFromBasket(int userId, int productId)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i => i.UserID == userId);
            var productBasketItem = await context.BasketProducts.FirstOrDefaultAsync(i=>i.BasketID == basket.BasketID && i.ProductID == productId);

            context.BasketProducts.Remove(productBasketItem);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
