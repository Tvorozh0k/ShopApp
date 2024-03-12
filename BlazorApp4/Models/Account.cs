using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BlazorApp4.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string Login { get; set; } = "";

        public string Password { get; set; } = "";

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } = "";
    }
}
