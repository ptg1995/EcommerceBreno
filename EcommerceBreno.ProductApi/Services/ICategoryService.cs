using EcommerceBreno.ProductApi.DTOs;
namespace EcommerceBreno.ProductApi.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
    Task<CategoryDTO> GetCategoryById(int id);
    Task<CategoryDTO> GetCategoryByName(string name);
    Task AddCategory(CategoryDTO categoryDTO);
    Task UpdateCategory(CategoryDTO categoryDTO);
    Task DeleteCategory(int id);
}
