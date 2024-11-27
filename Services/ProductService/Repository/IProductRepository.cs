using ProductsService.Models;

namespace ProductsService.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Save();
    }
}
