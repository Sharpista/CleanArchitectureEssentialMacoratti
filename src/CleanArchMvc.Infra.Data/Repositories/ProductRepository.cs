using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepoistory
    {
         private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _applicationDbContext.Add(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _applicationDbContext.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _applicationDbContext.Products.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
        } 

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _applicationDbContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveProductASync(Product product)
        {
            _applicationDbContext.Remove(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _applicationDbContext.Update(product);
            await _applicationDbContext.SaveChangesAsync();
            return product;
        }
    }
}
