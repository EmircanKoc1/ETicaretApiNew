using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BasketController : Controller
    {
        ETicaretDbContext context = new();


        [HttpGet("[action]")]
        public async Task<IActionResult> GetBaskets()
        {
            var basketList = await context.Baskets.ToListAsync(); ;

            return Ok(basketList);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasketByUserId(int id)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i => i.UserID == id );


            return Ok(basket);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasketByBasketId(int id)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i => i.BasketID == id);


            return Ok(basket);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasketItems(int userId)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i => i.UserID == userId);
            var basketItems = await context.BasketProducts.Where(i => i.BasketID == basket.BasketID).ToListAsync();

            return Ok(basketItems);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBasket(Basket basket)
        {
            await context.AddAsync(basket);
            await context.SaveChangesAsync();

            return Ok(basket);
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteBasketByBasketID(int id )
        {
            var getBasket = await context.Baskets.FirstOrDefaultAsync(b => b.BasketID == id);
            context.Baskets.Remove(getBasket);
            await context.SaveChangesAsync();
            return Ok(getBasket);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteBasketByUserID(int id)
        {
            var getBasket = await context.Baskets.FirstOrDefaultAsync(b =>b.UserID == id);
            context.Baskets.Remove(getBasket);
            await context.SaveChangesAsync();
            return Ok(getBasket);

        }


    }

}

