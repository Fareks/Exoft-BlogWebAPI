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
    public class CategoryImageRepository : IImageRepository<CategoryImage>
    {
        private readonly AppDbContext _dbcontext;

        public CategoryImageRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<CategoryImage> GetImage(Guid imageId, CancellationToken token = default)
        {
            var result = await _dbcontext.CategoryImage.SingleOrDefaultAsync(i => i.Id == imageId);
            return result;
        }

        public async Task<CategoryImage> GetImageByOwnerId(Guid categoryId, CancellationToken token = default)
        {
            var result = await _dbcontext.CategoryImage.SingleOrDefaultAsync(i => i.CategoryId == categoryId);
            return result;
        }

        public async Task UploadImage(CategoryImage image, CancellationToken token = default)
        {
            await _dbcontext.CategoryImage.AddAsync(image);
            await _dbcontext.SaveChangesAsync();

        }
        public async Task DeleteImage(CategoryImage image, CancellationToken token = default)
        {
            _dbcontext.CategoryImage.Remove(image);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
