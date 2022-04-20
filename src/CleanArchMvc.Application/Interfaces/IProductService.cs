using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface  IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int? id); 
        //Task<ProductDTO> GetProductCategory(int? id);
        Task Create(ProductDTO product);
        Task Update(ProductDTO product);
        Task Delete(int? id);
    }
}
