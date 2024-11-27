using ProductsService.Models;
using ProductsService.Repository;

namespace ProductsService.Service;

public class ProductService:IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public IEnumerable<Product> GetAllProducts()
    {
        return _productRepository.GetAll();
    }
    public Product AddProduct(Product product)
    {
        _productRepository.Add(product);
        _productRepository.Save();
        return product;
    }

}
