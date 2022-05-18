using EcommerceBreno.ProductApi.Context;
using EcommerceBreno.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBreno.ProductApi.Repositories
{
    //Classe de acesso ao banco de dados
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext? _context;


        public async Task<Category> Create(Category category)
        {
            try
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return category;
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Excessão na criação de categoria:  CategoryRepository.Create: {exc}");
            }
            
        }

        public async Task<Category> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                return await _context.Categories.ToListAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Excessão na criação de categoria:  CategoryRepository.GetAll: {exc}");
            }
            
        }

        public async Task<Category> GetById(int id)
        {
            try
            {
                if (id > 0)
                {
                    return await _context.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
                }
                else
                {
                    Console.WriteLine($"Id nulo");
                    return null;
                }              
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Excessão na criação de categoria:  CategoryRepository.GetById: {exc}");
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
