using BL.Exceptions;
using BL.Repositories;
using DB.DAO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAllAsync();
        }

        public Task<Product> Get(Guid productId)
        {
            return _productRepository.GetByIdAsync(productId);
        }

        public Task<IEnumerable<Product>> SearchByName(string name)
        {
            return _productRepository.GetByNameAsync(name);
        }

        public async Task Add(Product product)
        {
            Validate(product);
            await _productRepository.InsertAsync(product);
            await _productRepository.SaveAsync();
        }
        public async Task Add(IEnumerable<Product> products)
        {
            foreach (var p in products)
            {
                Validate(p);
            }
            await _productRepository.BulkInsertAsync(products);
            await _productRepository.SaveAsync();
        }
        public async Task Update(Product product)
        {
            Validate(product);
            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveAsync();
        }

        public async Task Delete(Guid productId)
        {
            await _productRepository.DeleteAsync(productId);
            await _productRepository.SaveAsync();
        }

        private void Validate(Product product)
        {
            if (String.IsNullOrWhiteSpace(product.Name))
                throw new InvalidProductException($"Invalid name - Product ID: {product.ProductId}");

            if (product.Price < 0)
                throw new InvalidProductException($"Invalid price - Product ID: {product.ProductId}");

            if (!Enum.IsDefined(typeof(Currency), product.Currency))
                throw new InvalidProductException($"Invalid currency - Product ID: {product.ProductId}");
        }
    }
}
