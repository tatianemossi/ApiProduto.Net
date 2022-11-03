using ProductApi.Net.Domain.Entity;
using System.Collections.Generic;

namespace ProductApi.Net.Domain.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Insert(Product product);
        Product Update(int id, Product product);
        void Delete(int id);
    }
}
