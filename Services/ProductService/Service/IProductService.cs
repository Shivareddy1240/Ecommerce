using ProductsService.Models;

namespace ProductsService.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product AddProduct(Product product);
    }
}
