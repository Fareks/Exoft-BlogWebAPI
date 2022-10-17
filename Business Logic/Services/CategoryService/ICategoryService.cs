using Business_Logic.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.CategoryService
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> GetAllCategories(CancellationToken token = default);
        public Task<CategoryDTO> CreateCategory(string categoryName, CancellationToken token = default);
        public Task DeleteCategory(Guid categoryId,CancellationToken token = default);
        public Task<CategoryDTO> GetCategoryById(Guid categoryId,CancellationToken token = default);
        public Task<List<CategoryDTO>> SearchCategoriesByName(string categoryName,CancellationToken token = default);
    }
}
