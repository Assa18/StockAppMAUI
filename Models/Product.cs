using SQLite;
using System.Text.Json.Serialization;

namespace StockAppMAUI.Models
{
    [Table("Products")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public float SupplyPrice {  get; set; }
        public float SellPrice {  get; set; }
    }

    [JsonSerializable(typeof(List<Product>))]
    internal sealed partial class ProductContext : JsonSerializerContext
    {
    }
}
