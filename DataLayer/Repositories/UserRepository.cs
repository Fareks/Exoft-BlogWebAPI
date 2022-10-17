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
    public class UserRepository : IUserRepository
    {
        AppDbContext _dbcontext;

        public UserRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task DeleteById(Guid id, CancellationToken token = default)
        {   
               _dbcontext.Users.Remove(await _dbcontext.Users.FindAsync(id));
        }

        public async Task<ICollection<User>> GetAllAsync(CancellationToken token = default)
        {
            var users = await _dbcontext.Users
                .Include(u => u.CommentLikes)
                .Include(u => u.PostLikes)
                .Include(u => u.Comments)
                .Include(u => u.UserImage).ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            var user = await _dbcontext.Users
                .Include(u => u.CommentLikes)
                .Include(u => u.PostLikes)
                .Include(u => u.Comments)
                .Include(u => u.UserImage).SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> GetByEmailAsync(string email, CancellationToken token = default)
        {
            var user = await _dbcontext.Users
                .Include(u => u.CommentLikes)
                .Include(u => u.PostLikes)
                .Include(u => u.Comments)
                .Include(u => u.UserImage).SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }
        public async Task<User> GetByEmailUsernameAsync(string email, string username, CancellationToken token = default)
        {
            var user = await _dbcontext.Users
                .Include(u => u.CommentLikes)
                .Include(u => u.PostLikes)
                .Include(u => u.Comments)
                .Include(u => u.UserImage).FirstOrDefaultAsync(u => (u.Email == email || u.UserName == username));
            return user;
        }

        public async Task Post(User user, CancellationToken token = default)
        {
            await _dbcontext.Users.AddAsync(user);
        }

        public async Task Save(CancellationToken token = default)
        {
           await _dbcontext.SaveChangesAsync();
        }

        public async Task Update(User user, CancellationToken token = default)
        {
           _dbcontext.Users.Update(user);
        }

    }
}
