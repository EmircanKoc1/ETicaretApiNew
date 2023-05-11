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
        ETicaretDbContext context = new();

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCommentByID(int id)
        {
            Comment commet = await context.Comments.FirstOrDefaultAsync(i => i.CommentID == id);

            return Ok(commet);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCommens()
        {
            var comments = await context.Comments.ToListAsync();
            return Ok(comments);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();

            return Ok();
        }

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
