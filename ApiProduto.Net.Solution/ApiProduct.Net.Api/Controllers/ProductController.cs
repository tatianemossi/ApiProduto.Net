using Microsoft.AspNetCore.Mvc;
using ProductApi.Net.Api.ViewModels;
using ProductApi.Net.Domain.Entity;
using ProductApi.Net.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ProductApi.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPost]
        public Product Post([FromBody] ProductViewModel productVM)
        {
            var product = new Product(productVM.Name, productVM.Price, productVM.Brand)
            {
                CreatedAt = DateTime.Now
            };
            return _productService.Insert(product);
        }

        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] ProductViewModel productVM)
        {
            var product = new Product(productVM.Name, productVM.Price, productVM.Brand)
            {
                Id = id
            };
            return _productService.Update(id, product);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}
