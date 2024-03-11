using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BlazorApp4.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

        public string ProductName { get; set; } = "";

        public int Price { get; set; } = 0;

        public string Description { get; set; } = "";

        public string Image { get; set; } = "/products/no_image.jpg";

        public int StockQuantity { get; set; } = 0;
    }
}
