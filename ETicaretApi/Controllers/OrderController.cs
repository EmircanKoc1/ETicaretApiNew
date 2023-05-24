using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    { //Controller yazıyoruz ve bu bizin ilgili istekleri yapacağımız api oluyor.
      //Aşağıdaki gibi tanımlıyoruz.

        //Burada veritabanına sorgu yapmak için bir context nesnesi oluşturuyoruz.
        ETicaretDbContext context = new();

        //Burada api ye post isteğinde bulunup order i user id ye göre getiriyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrdersByUserId(int userId)
        {
            var orders = await context.Orders.Where(i => i.UserID == userId).ToListAsync();

            return Ok(orders);
        }


        //Burada api ye get isteğinde bulunup orderdetailsi order id ye göre getiriyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetails = await context.OrderDetails.Where(i=>i.OrderID==orderId).ToListAsync();

            return Ok(orderDetails);
        }


        //Burada api ye get isteğinde bulunup order i order id ye göre getiriyoruz.
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderByOrderId(int orderId)
        {
            var order = await context.Orders.FirstOrDefaultAsync(i => i.OrderID == orderId);

            return Ok(order);
        }


        //Burada api ye post isteğinde bulunup order i user id ye göre getiriyoruz.
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


        //Burada api ye delete isteğinde bulunup order i order id ye göre  siliyoruz
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
