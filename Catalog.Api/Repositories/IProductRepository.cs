using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();

}