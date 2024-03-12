using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BlazorApp4.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Patronymic { get; set; } = "";

        public string Email { get; set; } = "";

        public string PhoneNumber { get; set; } = "";
    }
}
