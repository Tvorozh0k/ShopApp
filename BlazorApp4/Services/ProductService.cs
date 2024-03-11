using BlazorApp4.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazorApp4.Services
{
    public class ProductService : IService<Product>
    {
        private IMongoCollection<Product> _products;

        public ProductService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _products = database.GetCollection<Product>("Product");
        }

        public void Delete(string id)
        {
            _products.DeleteOne(x => x.Id == id);
        }

        public List<Product> GetAll()
        {
            return _products.Find(FilterDefinition<Product>.Empty).ToList();
        }

        public Product GetById(string id)
        {
            return _products.Find(x => x.Id == id).FirstOrDefault();
        }

        public void SaveOrUpdate(Product obj)
        {
            var ProductObj = _products.Find(x => x.Id == obj.Id).FirstOrDefault();

            if (ProductObj == null)
            {
                _products.InsertOne(obj);
            }
            else
            {
                _products.ReplaceOne(x => x.Id == obj.Id, obj);
            }
        }
    }
}
