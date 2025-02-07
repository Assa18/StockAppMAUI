using SQLite;
using StockAppMAUI.Models;

namespace StockAppMAUI.Service
{
    class DBService : AppService
    {
        private SQLiteAsyncConnection con;

        public async Task AddProductAsync(Product product)
        {
            await InitAsync();

            var query = con.Table<Product>().Where(p => p.ID == product.ID);

            if (await query.CountAsync() != 0)
            {
                await con.DeleteAsync<Product>(product.ID);
            }

            await con.InsertAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await InitAsync();

            await con.DeleteAsync<Product>(id);
        }

        public async Task InitAsync()
        {
            if (con != null)
            {
                return;
            }

            var dataBasePath = Path.Combine(FileSystem.AppDataDirectory, "StockAppData.db");

            con = new SQLiteAsyncConnection(dataBasePath);
            await con.CreateTableAsync<Product>();

            //var product = new Product()
            //{
            //    Name = "new product",
            //    SupplyPrice = 10,
            //    SellPrice = 15,
            //    Description = "This is a short description!"
            //};

            //await con.InsertAsync(product);
        }

        public async Task<List<Product>> LoadProductsAsync()
        {
            await InitAsync();

            var query = con.Table<Product>();

            var result = await query.ToListAsync();

            if (result == null)
            {
                return new List<Product>();
            }

            return result;
        }


    }
}
