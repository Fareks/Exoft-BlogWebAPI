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
        public Task<Category> CreateCategory(Category category,CancellationToken token = default);
        public Task DeleteCategory(Guid categoryId,CancellationToken token = default);
        public Task<List<Category>> GetAllCategories(CancellationToken token = default);
        public Task<Category> GetByIdAsync(Guid id,CancellationToken token = default);
        public Task<List<Category>> SearchByName(string name, CancellationToken token = default);
    }
}
