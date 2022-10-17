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

        public async Task<PostImage> GetImage(Guid imageId, CancellationToken token = default)
        {
            var result = await _dbcontext.PostImages.SingleOrDefaultAsync(i => i.Id == imageId);
            return result;
        }

        public async Task<PostImage> GetImageByOwnerId(Guid postId, CancellationToken token = default)
        {
            var result = await _dbcontext.PostImages.SingleOrDefaultAsync(i => i.PostId == postId);
            return result;
        }

        public async Task UploadImage(PostImage image, CancellationToken token = default)
        {
            await _dbcontext.PostImages.AddAsync(image);
            await _dbcontext.SaveChangesAsync();

        }
        public async Task DeleteImage(PostImage image, CancellationToken token = default)
        {
            _dbcontext.PostImages.Remove(image);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
