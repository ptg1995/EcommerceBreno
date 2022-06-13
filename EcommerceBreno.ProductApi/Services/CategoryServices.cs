using EcommerceBreno.ProductApi.DTOs;
using EcommerceBreno.ProductApi.Repositories;
using AutoMapper;
using EcommerceBreno.ProductApi.Models;

namespace EcommerceBreno.ProductApi.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly ICategoryRepository? _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository? categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(categoryEntity);
            categoryDTO.CategoryId = categoryDTO.CategoryId;
        }

        public async Task DeleteCategory(int id)
        {
            Category category = await _categoryRepository.GetById(id);
            await _categoryRepository.Delete(category.CategoryId);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var allCategories = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(allCategories);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            var categoriesProducts = await _categoryRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesProducts);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var categoryById = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoryById);
        }

        public async Task<CategoryDTO> GetCategoryByName(string name)
        {
            var categoryEntity = await _categoryRepository.GetAll();
            var GetCategoryByName = categoryEntity.Where(c => c.Name == name) ;
            return _mapper.Map<CategoryDTO>(GetCategoryByName);
        }

        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(categoryEntity);
        }
    }
}
