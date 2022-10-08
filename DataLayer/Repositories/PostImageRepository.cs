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
    public class PostImageRepository : IImageRepository<PostImage>
    {
        private readonly AppDbContext _dbcontext;

        public PostImageRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<PostImage> GetImage(Guid PostId)
        {
            var result = await _dbcontext.PostImages.SingleOrDefaultAsync(i => i.PostId == PostId);
            return result;
        }

        public async Task UploadImage(PostImage image)
        {
            await _dbcontext.PostImages.AddAsync(image);
            await _dbcontext.SaveChangesAsync();

        }
        public async Task DeleteImage(PostImage image)
        {
            _dbcontext.PostImages.Remove(image);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
