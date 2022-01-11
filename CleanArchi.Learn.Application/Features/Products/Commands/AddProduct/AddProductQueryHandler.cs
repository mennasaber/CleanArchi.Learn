using AutoMapper;
using CleanArchi.Learn.Application.Contracts;
using CleanArchi.Learn.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchi.Learn.Application.Features.Products.Commands.AddProduct
{
    public class AddProductQueryHandler : IRequestHandler<AddProductQuery, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AddProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddProductQuery request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            return (await _productRepository.AddAsync(product)).Id;
        }
    }
}
