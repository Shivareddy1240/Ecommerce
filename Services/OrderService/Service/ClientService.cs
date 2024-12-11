using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace OrderService.Service;

public class ClientService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<bool> IsProductAvailableAsync(int productId, int quantity)
    {
        var client = _httpClientFactory.CreateClient("ProductsService");
        var response = await client.GetAsync($"?productId = {productId}");
        if (!response.IsSuccessStatusCode) 
            return false;
        var product = JsonSerializer.Deserialize<Product>(
            await response.Content.ReadAsStringAsync(), new JsonSerializerOptions {PropertyNameCaseInsensitive=true });
        return product != null && product.Stock >= quantity;
    }
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

    }

}
