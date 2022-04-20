using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
            {
                throw new ApplicationException($"Entity could be not loaded");
            }
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }
        public async Task<ProductDTO> GetProductById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
            {
                throw new ApplicationException($"Entity could be not loaded");
            }
            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);

        //    if (productByIdQuery == null)
        //    {
        //        throw new ApplicationException($"Entity could be not loaded");
        //    }
        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Create(ProductDTO product)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(product);

            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO product)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(product);

            await _mediator.Send(productUpdateCommand);
        }
        public async Task Delete(int? id)
        {
            var productCommandRemove = new ProductRemoveCommand(id.Value);

            if (productCommandRemove == null) throw new ApplicationException($"Entity could be not loaded");
            await _mediator.Send(productCommandRemove);

        }


    }
}
