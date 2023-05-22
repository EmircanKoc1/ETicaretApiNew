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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetails = await context.OrderDetails.Where(i=>i.OrderID==orderId).ToListAsync();

            return Ok(orderDetails);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOrder(int id)
        {
            var userBasket = await context.Baskets.FirstOrDefaultAsync(i => i.UserID == id);
            var basketProducts = await context.BasketProducts.Where(i => i.BasketID == userBasket.BasketID).ToListAsync();

            float totalPrice = 0;
           

            foreach (var basketProduct in basketProducts)
            {
                totalPrice += basketProduct.Price;
            }

            Order order = new()
            {
                UserID = id,
                OrderDate = DateTime.UtcNow,
                TotalPrice = totalPrice,
                OrderStatus = false,
            };


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

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOrderById(int id)
        {
            var order = await context.Orders.FindAsync(id);
            context.Remove(order);
            await context.SaveChangesAsync();

            return Ok(order);
        }

    }
}
