using Microsoft.EntityFrameworkCore;
using EcommerceBreno.ProductApi.Models;
using EcommerceBreno.ProductApi.Context;
using EcommerceBreno.ProductApi.Models;

namespace EcommerceBreno.ProductApi.Repositories;

public class ProductRepository : IProductRepository
{
    readonly AppDBContext _context;
    public ProductRepository(AppDBContext context)
    {
        _context = context;
    }
    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Delete(int id)
    {  
        var productToDelete = await GetById(id);
        _context.Products.Remove(productToDelete);
        await _context.SaveChangesAsync();
        return productToDelete;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await _context.Products.Include(c => c.Category).Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Product> Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return product;
    }
}
