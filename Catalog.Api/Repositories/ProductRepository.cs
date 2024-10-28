using Catalog.Api.Data;
using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ICatalogContext _context;

    public ProductRepository(ICatalogContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.Find(p=>true).ToListAsync();
    }

    public async Task<Product> GetProductById(string id)
    {
        return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
    {
        return await _context.Products.Find(p => p.Category == categoryName).ToListAsync();
    }

    public async Task CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var updateResult = _context.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
        return updateResult.IsCompleted && updateResult.Result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProduct(string id)
    {
        var deleteResult = await _context.Products.DeleteOneAsync(p => p.Id == id);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}