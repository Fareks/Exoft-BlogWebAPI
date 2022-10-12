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
        public Task<List<CategoryDTO>> GetAllCategories();
        public Task<CategoryDTO> CreateCategory(string categoryName);
        public Task DeleteCategory(Guid categoryId);

        public Task<CategoryDTO> GetCategoryById(Guid categoryId);
    }
}
