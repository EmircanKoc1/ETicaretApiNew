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
        ETicaretDbContext context = new();

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasketProducts(int userId)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i=>i.UserID == userId);
            var basketItems = await context.BasketProducts.Where(i=>i.BasketID == basket.BasketID).ToListAsync();
           
            return Ok(basketItems);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddProductFromBasket(int userId , int productId)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i => i.UserID == userId);
            var product = await context.Products.FirstOrDefaultAsync(i=>i.ProductID == productId);
            BasketProduct basketProduct = new()
            {
                BasketID = basket.BasketID,
                ProductID = productId,
                Quantity = 1,
                Price = product.Price 
            };
            await context.BasketProducts.AddAsync(basketProduct);
            await context.SaveChangesAsync();

            return Ok(basketProduct);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteProductFromBasket(int userId, int productId)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i => i.UserID == userId);
            var productBasketItem = await context.BasketProducts.FirstOrDefaultAsync(i=>i.BasketProductID == productId);

            context.BasketProducts.Remove(productBasketItem);
            await context.SaveChangesAsync();
            return Ok();
        }





    }
}
