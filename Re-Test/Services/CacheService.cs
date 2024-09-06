
using StackExchange.Redis;
using System.Text.Json;

namespace Re_Test.Services
{
    public class CacheService : ICacheService
    {
        private IDatabase _database;


        public CacheService()
        {
            var redisConfig = new ConfigurationOptions
            {
                EndPoints = { "localhost:5001" },
                Password = "mySecretPassword",
                AbortOnConnectFail = false,
                ConnectRetry = 10
            };

            var redis = ConnectionMultiplexer.Connect(redisConfig);
            _database = redis.GetDatabase();
            _database.Ping();
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

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expTime = expirationTime.Subtract(DateTime.Now);
            return _database.StringSet(key, JsonSerializer.Serialize(value), expTime);
        }
    }
}
