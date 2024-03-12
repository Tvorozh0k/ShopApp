using BlazorApp4.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorApp4.Services
{
    public class AccountService : IService<Account>
    {
        private IMongoCollection<Account> _accounts;

        public AccountService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _accounts = database.GetCollection<Account>("Account");
        }

        public void Delete(string id)
        {
            _accounts.DeleteOne(x => x.Id == id);
        }

        public List<Account> GetAll()
        {
            return _accounts.Find(FilterDefinition<Account>.Empty).ToList();
        }

        public Account GetById(string id)
        {
            return _accounts.Find(x => x.Id == id).FirstOrDefault();
        }

        public void SaveOrUpdate(Account obj)
        {
            var accountObj = _accounts.Find(x => x.Id == obj.Id).FirstOrDefault();

            if (accountObj == null)
            {
                _accounts.InsertOne(obj);
            }
            else
            {
                _accounts.ReplaceOne(x => x.Id == obj.Id, obj);
            }
        }
    }
}
