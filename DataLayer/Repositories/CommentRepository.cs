using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        AppDbContext _dbcontext;

        public CommentRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task Delete(Guid id)
        {
            var comment = await _dbcontext.Comment.SingleOrDefaultAsync(u => u.Id == id);
            if (comment != null)
            {
                _dbcontext.Comment.Remove(comment);
            }
        }

        public async Task<ICollection<Comment>> GetAllAsync()
        {
            var comment = await _dbcontext.Comment.Include(c => c.User).ToListAsync();
            return comment;
        }

        public async Task<Comment> GetByIdAsync(Guid id)
        {
            var comment = await _dbcontext.Comment
                .Include(c => c.User).SingleOrDefaultAsync(u => u.Id == id);
            return comment;
        }

        public async Task Post(Comment comment)
        {
            await _dbcontext.Comment.AddAsync(comment);
        }

        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Update(Comment comment)
        {
            _dbcontext.Comment.Update(comment);
        }
    }
}
