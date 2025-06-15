// Data/MongoDbContext.cs
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using EQUIPO_LINCES_BACKEND.Settings;

namespace EQUIPO_LINCES_BACKEND.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDBSettings> settings, IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
