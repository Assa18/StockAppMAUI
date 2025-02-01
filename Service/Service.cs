using StockAppMAUI.Models;

namespace StockAppMAUI.Service
{
    interface AppService
    {
        public Task<List<Product>> LoadProductsAsync();
    }
}
