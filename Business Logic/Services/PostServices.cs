using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic.Services
{
    public class PostServices : ICRUDService<Post>
    {
        AppDbContext dbContext;

        public PostServices(AppDbContext _db)
        {
            dbContext = _db;
        }
        public async Task<IEnumerable<Post>> GetAll()
        {
            var posts = await dbContext.Posts.ToListAsync();
            return posts;
        }
        public async Task<Post> GetById(Guid id)
        {
            var post = await dbContext.Posts.SingleOrDefaultAsync(p => p.Id == id);
            return (post);
        }
        public async Task Update(Post post)
        {
            dbContext.Update(post);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteById(Guid id)
        {
            if (GetById(id) != null)
            {
                dbContext.Posts.Remove(await GetById(id));
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task Post(Post newPost)
        {
           await dbContext.Posts.AddAsync(newPost);
           await dbContext.SaveChangesAsync();
        }

    }
}
