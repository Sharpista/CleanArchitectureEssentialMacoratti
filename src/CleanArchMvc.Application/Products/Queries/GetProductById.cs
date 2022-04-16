using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Queries
{
    public  class GetProductById : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductById(int id)
        {
                Id = id;
        }
    }
}
