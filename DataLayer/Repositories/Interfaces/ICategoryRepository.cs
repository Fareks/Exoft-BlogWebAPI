using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateCategory(Category category);
        public Task DeleteCategory(Guid categoryId);
        public Task<List<Category>> GetAllCategories();
        public Task<Category> GetByIdAsync(Guid id);
    }
}
