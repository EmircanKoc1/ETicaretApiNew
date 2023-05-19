using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        ETicaretDbContext context = new();


        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersByUserId(int userId)
        {
            var orders = await context.Orders.Where(i => i.UserID == userId).ToListAsync();

            return Ok(orders);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            var userBasket = await context.Baskets.FirstOrDefaultAsync(i => i.UserID == order.UserID);
            var basketProducts = await context.BasketProducts.Where(i => i.BasketID == userBasket.BasketID).ToListAsync();

            float totalPrice = 0;

            foreach (var basketProduct in basketProducts)
            {
                totalPrice += basketProduct.Price;
            }
            order.TotalPrice = totalPrice;

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
         

            foreach (var item in basketProducts)
            {
                OrderDetail orderDetailItem = new()
                {
                    OrderID = order.OrderID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                };

                await context.OrderDetails.AddAsync(orderDetailItem);

            }
            await context.SaveChangesAsync();

            return Ok(order);
        }



    }
}
