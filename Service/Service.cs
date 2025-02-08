using StockAppMAUI.Models;

namespace StockAppMAUI.Service
{
    interface AppService
    {
        public Task InitAsync();

        public Task<List<Product>> LoadProductsAsync();

        public Task AddProductAsync(Product product);

        public Task DeleteProductAsync(int id);

        public Task<List<Transaction>> LoadAllTransactionsAsync();
    }
}
