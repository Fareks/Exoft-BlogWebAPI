using AutoMapper;
using Business_Logic.DTO.CategoryDTOs;
using DataLayer.Models;
using DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> CreateCategory(string categoryName, CancellationToken token = default)
        {
            CategoryCreateDTO categoryDTO = new CategoryCreateDTO();
            categoryDTO.CategoryName = categoryName;
            var category = _mapper.Map<Category>(categoryDTO);
            var response = await _categoryRepository.CreateCategory(category, token);
            return _mapper.Map<CategoryDTO>(response);
        }

        public async Task<List<CategoryDTO>> GetAllCategories(CancellationToken token = default)
        {
            var response = await _categoryRepository.GetAllCategories(token);
            var categories = _mapper.Map<List<CategoryDTO>>(response);
            return categories;
        }

        public async Task DeleteCategory(Guid categoryId, CancellationToken token = default)
        {
            await _categoryRepository.DeleteCategory(categoryId, token);
        }

        public async Task<CategoryDTO> GetCategoryById(Guid categoryId, CancellationToken token = default)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId, token);
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            return categoryDTO;
        }

        public async Task<List<CategoryDTO>> SearchCategoriesByName(string categoryName, CancellationToken token = default)
        {
            var categories = await _categoryRepository.SearchByName(categoryName, token);
            var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories);
            return categoriesDTO;
        }
    }
}
