using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>>GetCategories();
        Task<CategoryDTO> GetCategoryById(int? id);
        Task Create(CategoryDTO category);
        Task Update(CategoryDTO category);
        Task Delete(int? id);
    }
}
