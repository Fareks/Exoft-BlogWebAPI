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

        public async Task DeleteById(Guid id)
        {   
               _dbcontext.Users.Remove(await _dbcontext.Users.FindAsync(id));
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            var users = await _dbcontext.Users
                .Include(u => u.CommentLikes)
                .Include(u => u.PostLikes)
                .Include(u => u.Comments)
                .Include(u => u.UserImage).ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _dbcontext.Users
                .Include(u => u.CommentLikes)
                .Include(u => u.PostLikes)
                .Include(u => u.Comments)
                .Include(u => u.UserImage).SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _dbcontext.Users
                .Include(u => u.CommentLikes)
                .Include(u => u.PostLikes)
                .Include(u => u.Comments)
                .Include(u => u.UserImage).SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task Post(User user)
        {
            await _dbcontext.Users.AddAsync(user);
        }

        public async Task Save()
        {
           await _dbcontext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
           _dbcontext.Users.Update(user);
        }

    }
}
