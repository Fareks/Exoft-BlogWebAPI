﻿using DataLayer.Models;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserImageRepository : IImageRepository<UserImage>   
    {
        private readonly AppDbContext _dbcontext;

        public UserImageRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        

        public async Task<UserImage> GetImage(Guid UserId)
        {
            var result = await _dbcontext.UserImages.SingleOrDefaultAsync(i => i.UserId == UserId);
            return result;
        }

        public async Task UploadImage(UserImage image)
        {
            await _dbcontext.UserImages.AddAsync(image);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteImage(UserImage image)
        {
            _dbcontext.UserImages.Remove(image);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
