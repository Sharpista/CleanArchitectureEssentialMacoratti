using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public  class ProductService : IProductService
    {
        private IProductRepository _productRepoistory;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepoistory, IMapper mapper)
        {
            _productRepoistory = productRepoistory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsEntity = await _productRepoistory.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }
        public async Task<ProductDTO> GetProductByIdAsync(int? id)
        {
            var productEntity = await _productRepoistory.GetProductByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productEntity = await _productRepoistory.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task AddAsync(ProductDTO product)
        {
            var productEntiy =  _mapper.Map<Product>(product);
            await _productRepoistory.CreateProductAsync(productEntiy);
        }

        public async Task UpdateAsync(ProductDTO product)
        {
            var productEntiy = _mapper.Map<Product>(product);
            await _productRepoistory.UpdateProductAsync(productEntiy);
        }
        public async Task DeleteAsync(int? id)
        {
            var productEntity = _productRepoistory.GetProductByIdAsync(id).Result;

            await _productRepoistory.RemoveProductASync(productEntity);
        }


    }
}
