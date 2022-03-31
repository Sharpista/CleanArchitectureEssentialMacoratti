using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _applicationDbContext.Add(category);
            await _applicationDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _applicationDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int? id)
        {
           return await _applicationDbContext.Categories.FindAsync(id);
        }

        public async Task<Category> RemoveCategoryASync(Category category)
        {
            _applicationDbContext.Remove(category);
            await _applicationDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _applicationDbContext.Update(category);
            await _applicationDbContext.SaveChangesAsync();
            return category;
        }
    }
}
