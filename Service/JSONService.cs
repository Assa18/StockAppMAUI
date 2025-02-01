using StockAppMAUI.Models;
using System.Text.Json;

namespace StockAppMAUI.Service
{
    class JSONService : AppService
    {
        List<Product> products;
        public async Task<List<Product>> LoadProductsAsync()
        {
            using var fileStream = await FileSystem.OpenAppPackageFileAsync("Products.json");
            using var reader = new StreamReader(fileStream);
            var contents = await reader.ReadToEndAsync();
            if (contents == null)
            {
                return new List<Product>();
            }
            products = JsonSerializer.Deserialize(contents, ProductContext.Default.ListProduct);

            return products;
        }
    }
}
