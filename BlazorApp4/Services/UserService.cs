using BlazorApp4.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorApp4.Services
{
    public class UserService : IService<User>
    {
        private IMongoCollection<User> _users;

        public UserService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _users = database.GetCollection<User>("User");
        }

        public void Delete(string id)
        {
            _users.DeleteOne(x => x.Id == id);
        }

        public User GetById(string id)
        {
            return _users.Find(x => x.Id == id).FirstOrDefault();
        }

        public List<User> GetAll()
        {
            return _users.Find(FilterDefinition<User>.Empty).ToList();
        }

        public void SaveOrUpdate(User obj)
        {
            var userObj = _users.Find(x => x.Id == obj.Id).FirstOrDefault();

            if (userObj == null)
            {
                _users.InsertOne(obj);
            }
            else
            {
                _users.ReplaceOne(x => x.Id == obj.Id, obj);
            }
        }
    }
}
