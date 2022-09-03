﻿using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserRepository : IRepository<User>
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
                .Include(u => u.commentLikes)
                .Include(u => u.postLikes)
                .Include(u => u.Comments).ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _dbcontext.Users
                .Include(u => u.commentLikes)
                .Include(u => u.postLikes)
                .Include(u => u.Comments).SingleOrDefaultAsync(u => u.Id == id);
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
