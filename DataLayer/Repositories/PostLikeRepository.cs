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
    public class PostLikeRepository : IPostLikeRepository
    {
        AppDbContext _dbcontext;

        public PostLikeRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task DeleteById(Guid id)
        {
            var postLike = await _dbcontext.PostLike.FirstOrDefaultAsync(u => u.Id == id);
            if (postLike != null)
            {
                _dbcontext.PostLike.Remove(postLike);
            }
        }

        public async Task<ICollection<PostLike>> GetAllAsync()
        {
            var postLike = await _dbcontext.PostLike.ToListAsync();
            return postLike;
        }
        public async Task<List<PostLike>> GetByPostIdAsync(Guid postId)
        {
            var postLikes =  _dbcontext.PostLike
                .Where(p => p.PostId == postId);
            return (postLikes.ToList());
        }

        public async Task<PostLike> GetByIdAsync(Guid id)
        {
            var postLike = await _dbcontext.PostLike.SingleOrDefaultAsync(u => u.Id == id);
            return postLike;
        }

        
        //toogle
        public async Task Post(PostLike postLike)
        {

            await _dbcontext.PostLike.AddAsync(postLike);
        }

        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Update(PostLike postLike)
        {
            _dbcontext.PostLike.Update(postLike);
        }

        public async Task ToggleLike(PostLike postLike)
        {
            var oldPostLike = await _dbcontext.PostLike.FirstOrDefaultAsync(u => u.PostId == postLike.PostId && u.UserId  == postLike.UserId);

            if (oldPostLike != null)
            {
                await DeleteById(oldPostLike.Id);

            }
            else
            {
                await Post(postLike);
            }
        }

        public async Task<List<PostLike>> GetAllPostLikesByUserId(Guid userId)
        {
            var postLikesWithPosts = _dbcontext.PostLike
               .Include(p => p.Post)
               .ThenInclude(p => p.Category)
               .Where(p => p.UserId == userId);
            return (postLikesWithPosts.ToList());
        }


    }
}
