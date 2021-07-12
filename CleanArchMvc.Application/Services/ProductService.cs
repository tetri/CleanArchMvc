using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;

using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        //private IProductRepository _productReporitory;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(/*IProductRepository productRepository, */IMapper mapper, IMediator mediator)
        {
            //_productReporitory = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            //var productsEntity = await _productReporitory.GetProductsAsync();

            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
                throw new Exception("Entity could not be loaded.");

            var productsEntity = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            //var productEntity = await _productReporitory.GetByIdAsync(id);

            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null)
                throw new Exception("Entity could not be loaded.");

            var productEntity = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        //fere o DRY
        //public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        //{
        //    //var productEntity = await _productReporitory.GetProductCategoryAsync(id);
        //
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);
        //    if (productByIdQuery == null)
        //        throw new Exception("Entity could not be loaded.");
        //
        //    var productEntity = await _mediator.Send(productByIdQuery);
        //    return _mapper.Map<ProductDTO>(productEntity);
        //}

        public async Task AddAsync(ProductDTO productDTO)
        {
            //var productEntity = _mapper.Map<Product>(productDTO);
            //await _productReporitory.CreateAsync(productEntity);

            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            //var productEntity = _mapper.Map<Product>(productDTO);
            //await _productReporitory.UpdateAsync(productEntity);

            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task RemoveAsync(int? id)
        {
            //var productEntity = await _productReporitory.GetByIdAsync(id); //.Result ???
            //await _productReporitory.RemoveAsync(productEntity);

            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
                throw new Exception("Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
