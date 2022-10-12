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
    public class CategoryRepository : ICategoryRepository
    {
        readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await _appDbContext.Category.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            var category = _appDbContext.Category.SingleOrDefault(c => c.Id == categoryId);
            if(category != null)
            {
                _appDbContext.Category.Remove(category);
            }
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<List<Category>> GetAllCategories()
        {
            var response =  await _appDbContext.Category.Include(c => c.CategoryImage).ToListAsync();
            return response;
        }
        public async Task<Category> GetByIdAsync(Guid id)
        {
            var category = await _appDbContext.Category.SingleOrDefaultAsync(u => u.Id == id);
            return category;
        }
    }
}
