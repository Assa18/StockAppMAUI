using SQLite;
using StockAppMAUI.Models;

namespace StockAppMAUI.Service
{
    class DBService : AppService
    {
        private SQLiteAsyncConnection con;

        public async Task InitAsync()
        {
            if (con != null)
            {
                return;
            }

            var dataBasePath = Path.Combine(FileSystem.AppDataDirectory, "StockAppData.db");

            con = new SQLiteAsyncConnection(dataBasePath);

            await con.CreateTableAsync<Product>();
            await con.CreateTableAsync<Transaction>();
        }

        public async Task AddProductAsync(Product product)
        {
            await InitAsync();

            var query = con.Table<Product>().Where(p => p.PID == product.PID);

            if (await query.CountAsync() != 0)
            { 
                await con.UpdateAsync(product);
                return;
            }

            await con.InsertAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await InitAsync();

            await con.DeleteAsync<Product>(id);
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

        public async Task<List<Transaction>> LoadAllTransactionsAsync()
        {
            await InitAsync();

            var query = con.Table<Transaction>();

            var result = await query.ToListAsync();

            if (result == null)
            {
                return new List<Transaction>();
            }

            return result;
        }
    }
}