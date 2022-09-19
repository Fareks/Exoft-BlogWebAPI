using DataLayer.Models;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class PostRepository : IPostRepository
    {
        AppDbContext _dbcontext;

        public PostRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task DeleteById(Guid id)
        {
            var post = await _dbcontext.Posts.SingleOrDefaultAsync(u => u.Id == id);
            if (post != null)
            {
                _dbcontext.Posts.Remove(post);
            }
        }

        public async Task<ICollection<Post>> GetAllAsync()
        {
            var posts = await _dbcontext.Posts.Include(p => p.PostLikes).Include(p => p.User).ToListAsync();
            return posts;
        }

        public async Task<Post> GetByIdAsync(Guid id)
        {
            var post = await _dbcontext.Posts
                .Include(p => p.PostLikes).Include(p => p.User).SingleOrDefaultAsync(u => u.Id == id);
            return post;
        }
        public async Task<List<Post>> GetAllByUserId (Guid userId)
        {
            var posts = _dbcontext.Posts.Where(p => p.UserId == userId);
            return posts.ToList();
        }

        public async Task Post(Post post)
        {
            await _dbcontext.Posts.AddAsync(post);
        }

        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Update(Post post)
        {
            _dbcontext.Posts.Update(post);
        }
        public async Task UpdateLikeSnapshot(Guid id)
        {
            var post = _dbcontext.Posts.SingleOrDefault(p => p.UserId == id);
            if (post != null)
            {
               post.LikeSnapshot = post.PostLikes.Count;
            }
            
        }
    }
}
