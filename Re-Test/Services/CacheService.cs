
using StackExchange.Redis;
using System.Text.Json;

namespace Re_Test.Services
{
    public class CacheService : ICacheService
    {
       private IDatabase _database;

        public CacheService()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:7090");
            _database = redis.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            return JsonSerializer.Deserialize<T>(_database.StringGet(key)!)!;
        }

        public bool RemoveData(string key)
        {
            if (_database.KeyExists(key))
            {
                return _database.KeyDelete(key);
            }

            return false;
        }

        public bool SetData<T>(string key, T value)
        {
            return _database.StringSet(key, JsonSerializer.Serialize(value));
        }
    }
}
