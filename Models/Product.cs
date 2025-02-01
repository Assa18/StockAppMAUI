using System.Text.Json.Serialization;

namespace StockAppMAUI.Models
{
    public class Product
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public float SupplyPrice {  get; set; }
        public float SellPrice {  get; set; }
        public bool OnStock { get; set; }
        public int Count {  get; set; }
    }

    [JsonSerializable(typeof(List<Product>))]
    internal sealed partial class ProductContext : JsonSerializerContext
    {
    }
}
