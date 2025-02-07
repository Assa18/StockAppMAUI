using StockAppMAUI.Models;

namespace StockAppMAUI.Service
{
    interface AppService
    {
        public Task<List<Product>> LoadProductsAsync();

        public Task InitAsync();

        public Task AddProductAsync(Product product);

        public Task DeleteProductAsync(int id);
    }
}
