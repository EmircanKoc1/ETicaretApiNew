using ETicaretApi.Context;
using ETicaretApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        //Controller yazıyoruz ve bu bizin ilgili istekleri yapacağımız api oluyor.
        //Aşağıdaki gibi tanımlıyoruz.

        //Burada veritabanına sorgu yapmak için bir context nesnesi oluşturuyoruz.
        ETicaretDbContext context = new();

        //Burada api ye get isteğinde bulunup commenti id ye göre getiriyoruz
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCommentByID(int id)
        {
            Comment comment = await context.Comments.FirstOrDefaultAsync(i => i.CommentID == id);

            return Ok(comment);
        }

        //Burada api ye get isteğinde bulunup commenti product id ye göre getiriyoruz
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCommentsByProductID(int id)
        {
            var comments = await context.Comments.Where(i => i.ProductID == id).ToListAsync();

            return Ok(comments);
        }

        //Burada api ye get isteğinde bulunup commenti product id ye göre getiriyoruz
        [HttpGet("[action]")]
        public async Task<IActionResult> GetComments()
        {
            var comments = await context.Comments.ToListAsync();
            return Ok(comments);
        }

        //Burada api ye post isteğinde bulunup comment ekliyoruz
        [HttpPost("[action]")]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();

            return Ok();
        }

        //Burada api ye put isteğinde bulunup commenti güncelliyoruz
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            Comment getComment = await context.Comments.FirstOrDefaultAsync(i => i.CommentID == comment.CommentID);
          
            getComment.ProductID = comment.ProductID;
            getComment.UserID = comment.UserID;
            getComment.Content = comment.Content;
            getComment.Score = comment.Score;

            await context.SaveChangesAsync();
          
            return Ok(getComment);
        }

        //Burada api ye post isteğinde bulunup commenti siliyoruz
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCommentByID(int id)
        {
            Comment commet = await context.Comments.FirstOrDefaultAsync(i => i.CommentID == id);
            
            context.Comments.Remove(commet);
            await context.SaveChangesAsync();

            return Ok(commet);

        }

    }
}
