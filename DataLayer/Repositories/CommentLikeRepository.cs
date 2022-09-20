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
    public class CommentLikeRepository : IRepository<CommentLike>
    {
        AppDbContext _dbcontext;

        public CommentLikeRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task DeleteById(Guid id)
        {
            var commLike = await _dbcontext.CommentLike.SingleOrDefaultAsync(u => u.Id == id);
            if (commLike != null)
            {
                _dbcontext.CommentLike.Remove(commLike);
            }
        }

        public async Task<ICollection<CommentLike>> GetAllAsync()
        {
            var commLike = await _dbcontext.CommentLike.ToListAsync();
            return commLike;
        }

        public async Task<CommentLike> GetByIdAsync(Guid id)
        {
            var commLike = await _dbcontext.CommentLike.SingleOrDefaultAsync(u => u.Id == id);
            return commLike;
        }

        public async Task Post(CommentLike commLike)
        {
            await _dbcontext.CommentLike.AddAsync(commLike);
        }

        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Update(CommentLike commLike)
        {
            _dbcontext.CommentLike.Update(commLike);
        }
    }
}
