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

        public async Task DeleteById(Guid id, CancellationToken token = default)
        {
            var post = await _dbcontext.Posts.SingleOrDefaultAsync(u => u.Id == id);
            if (post != null)
            {
                _dbcontext.Posts.Remove(post);
            }
        }

        public async Task<ICollection<Post>> GetAllAsync(CancellationToken token = default)
        {
            var posts = await _dbcontext.Posts.Include(p => p.PostLikes)
                .Include(p => p.User)
                .Include(u => u.PostImage)
                .Include(p => p.Category)
                .ToListAsync(); 
            return posts;
        }

        public async Task<Post> GetByIdAsync(Guid id,CancellationToken token = default)
        {
            var post = await _dbcontext.Posts
                .Include(p => p.PostLikes)
                .Include(p => p.User)
                .Include(u => u.PostImage)
                .Include(p => p.Category)
                .SingleOrDefaultAsync(u => u.Id == id);
            return post;
        }
        public async Task<List<Post>> GetAllByUserId (Guid userId,CancellationToken token = default)
        {
            var posts = _dbcontext.Posts
                .Include(u => u.PostImage)
                .Include(p => p.Category)
                .Where(p => p.UserId == userId);
            return posts.ToList();
        }

        //public async Task<List<Post>> GetAllLikedPostsByUserId(Guid userId)
        //{
        //    var posts = _dbcontext.Posts
        //        .Include(u => u.PostImage)
        //        .Include(p => p.Category)
        //        .Include(p => p.PostLikes)
        //    return posts.ToList();
        //}

        public async Task Post(Post post,CancellationToken token = default)
        {
            await _dbcontext.Posts.AddAsync(post);
        }

        public async Task Save(CancellationToken token = default)
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Update(Post post,CancellationToken token = default)
        {
            _dbcontext.Posts.Update(post);
        }

        public async Task<int> UpdateLikeSnapshot(Guid id,CancellationToken token = default)
        {
            var post = _dbcontext.Posts.Include( p => p.PostLikes).SingleOrDefault(p => p.Id == id);
            if (post != null)
            {
               post.LikeSnapshot = post.PostLikes.Count;
            }
            
            await _dbcontext.SaveChangesAsync();
            return post.LikeSnapshot;
            
        }

        public async Task<List<Post>> GetAllUnverifiedPosts(CancellationToken token = default)
        {
            var posts = _dbcontext.Posts
                .Include(p => p.PostImage)
                .Include(p => p.User)
                .ThenInclude(u => u.UserImage)
                .Include(p => p.Category)
                .Where(p => p.VerifyStatus == false);
            return posts.ToList();
        }

        public async Task<List<Post>> GetPostsByCategoryId(Guid categoryId,CancellationToken token = default)
        {
            var posts = _dbcontext.Posts
                .Include(p => p.PostImage)
                .Include(p => p.User)
                .ThenInclude(u => u.UserImage)
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId);
            return posts.ToList();
        }
        
        public async Task<List<Post>> GetLastPosts(int skip, int take,CancellationToken token = default)
        {
            var posts = _dbcontext.Posts
               .Include(p => p.PostImage)
               .Include(p => p.User)
               .ThenInclude(u => u.UserImage)
               .Include(p => p.Category)
               .Where(p => p.VerifyStatus == true)
               .OrderByDescending(p => p.CreatedDate)
               .Skip(skip)
               .Take(take);
            return posts.ToList();
        }

        public async Task<IEnumerable<Post>> SearchByContent(string content,CancellationToken token = default)
        {
            var posts = _dbcontext.Posts
               .Include(p => p.PostImage)
               .Include(p => p.User)
               .ThenInclude(u => u.UserImage)
               .Include(p => p.Category)
               .Where(p => p.VerifyStatus == true)
               .Where(p => p.TextContent.Contains(content) || p.Title.Contains(content))
               .OrderByDescending(p => p.CreatedDate);
            return posts.ToList();
        }
    }
}
