using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class PostLikeRepository : IRepository<PostLike>
    {
        AppDbContext _dbcontext;

        public PostLikeRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task DeleteById(Guid id)
        {
            var postLike = await _dbcontext.PostLike.SingleOrDefaultAsync(u => u.Id == id);
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

        public async Task<PostLike> GetByIdAsync(Guid id)
        {
            var postLike = await _dbcontext.PostLike.SingleOrDefaultAsync(u => u.Id == id);
            return postLike;
        }

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
    }
}
