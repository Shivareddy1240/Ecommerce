using ProductsService.Data;
using ProductsService.Models;

namespace ProductsService.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ProductsDbContext _dbContext;
    public ProductRepository(ProductsDbContext productsDbContext)
    {
        _dbContext = productsDbContext;
    }

    public IEnumerable<Product> GetAll()
    {
        return _dbContext.Products.ToList();
    }
    public Product GetById(int id)
    {
        return _dbContext.Products.FirstOrDefault(p => p.Id == id);
    }
    public void Add(Product product)
    {
        _dbContext.Products.Add(product);
    }
    public void Save()
    {
        _dbContext.SaveChanges();
    }
}