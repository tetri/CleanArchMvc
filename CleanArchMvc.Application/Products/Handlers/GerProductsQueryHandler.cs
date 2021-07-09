﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class GerProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {

        private readonly IProductRepository _productRepository;

        public GerProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
