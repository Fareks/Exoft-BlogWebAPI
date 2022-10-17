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

        public async Task<Category> CreateCategory(Category category,CancellationToken token = default)
        {
            await _appDbContext.Category.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategory(Guid categoryId, CancellationToken token = default)
        {
            var category = _appDbContext.Category.SingleOrDefault(c => c.Id == categoryId);
            if(category != null)
            {
                _appDbContext.Category.Remove(category);
            }
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<List<Category>> GetAllCategories(CancellationToken token = default)
        {
            var response =  await _appDbContext.Category.Include(c => c.CategoryImage).ToListAsync();
            return response;
        }
        public async Task<Category> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            var category = await _appDbContext.Category.Include(c => c.CategoryImage).SingleOrDefaultAsync(u => u.Id == id);
            return category;
        }
        public async Task<List<Category>> SearchByName(string name, CancellationToken token = default)
        {
            var category = await _appDbContext.Category.Where(u => u.CategoryName.Contains(name)).ToListAsync();
            return category;
        }
    }
}
