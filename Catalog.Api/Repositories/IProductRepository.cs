using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    
    Task<Product> GetProductById(string id);
    Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
    Task CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string id);
    
}