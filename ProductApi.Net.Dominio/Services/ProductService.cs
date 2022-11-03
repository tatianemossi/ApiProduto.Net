using ProductApi.Net.Domain.Entity;
using ProductApi.Net.Domain.Interfaces.Repositories;
using ProductApi.Net.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ProductApi.Net.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product Insert(Product product)
        {
            return _productRepository.Insert(product);
        }

        public Product Update(int id, Product product)
        {
            _productRepository.Update(id, product);

            return _productRepository.GetById(id);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
