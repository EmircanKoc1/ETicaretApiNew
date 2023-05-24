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
        //Controller yazıyoruz ve bu bizin ilgili istekleri yapacağımız api oluyor.
        //Aşağıdaki gibi tanımlıyoruz.

        //Burada veritabanına sorgu yapmak için bir context nesnesi oluşturuyoruz.
        ETicaretDbContext context = new();


        //Burada api ye get isteğinde bulunup sepet toplam tutarı alıyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasketTotal(int userId)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i => i.UserID == userId);
            var basketProducts = await context.BasketProducts.Where(i => i.BasketID == basket.BasketID).ToListAsync();
            float totalPrice = 0;

            foreach (var basketProduct in basketProducts)
            {
                totalPrice += basketProduct.Price;
            }

            return Ok(totalPrice);
        }


        //Burada api ye get isteğinde bulunup sepetleri listeliyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBaskets()
        {
            var basketList = await context.Baskets.ToListAsync(); 

            return Ok(basketList);
        }

        //Burada api ye get isteğinde bulunup user a ait sepeti alıyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasketByUserId(int id)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i => i.UserID == id );


            return Ok(basket);
        }

        //Burada api ye get isteğinde bulunup sepet ıd sine göre sepeti alıyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasketByBasketId(int id)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i => i.BasketID == id);


            return Ok(basket);
        }

        //Burada api ye get isteğinde bulunup sepettekileri listeliyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBasketItems(int userId)
        {
            var basket = await context.Baskets.FirstOrDefaultAsync(i => i.UserID == userId);
            var basketItems = await context.BasketProducts.Where(i => i.BasketID == basket.BasketID).ToListAsync();

            return Ok(basketItems);
        }
        //Burada api ye post isteğinde bulunup sepet oluşturuyoruz.
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBasket(Basket basket)
        {
            await context.AddAsync(basket);
            await context.SaveChangesAsync();

            return Ok(basket);
        }

        //Burada api ye delete isteğinde bulunup sepet ıd sine göre sepeti siliyoruz
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteBasketByBasketID(int id )
        {
            var getBasket = await context.Baskets.FirstOrDefaultAsync(b => b.BasketID == id);
            context.Baskets.Remove(getBasket);
            await context.SaveChangesAsync();
            return Ok(getBasket);
        }
        //Burada api ye delete isteğinde bulunup user ıd sine göre sepeti siliyoruz
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

