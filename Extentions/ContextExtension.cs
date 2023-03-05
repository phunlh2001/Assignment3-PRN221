using Assignment3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Extentions
{
    public static class ContextExtension
    {
        public static Post SearchByText(this ApplicationDbContext context, string text)
        {
            var result = context.Posts
                .Include(p => p.Author)
                .Include(p => p.PostCategory)
                .FirstOrDefault(e => e.Title.Contains(text));
            return result ?? null;
        }

        public static async Task<List<Post>> GetList(this ApplicationDbContext context)
        {
            var post = context.Posts
                .Include(p => p.Author)
                .Include(p => p.PostCategory);
            return await post.ToListAsync();
        }
    }
}
