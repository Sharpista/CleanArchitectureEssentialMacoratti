using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepoistory;

        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepoistory = productRepository;
        }
        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = _productRepoistory.GetProductByIdAsync(request.Id).Result;

            if (product == null)  throw new ApplicationException($"Error could be not found");

            var result =  await _productRepoistory.RemoveProductASync(product);

            return result;
        }
    }
}
