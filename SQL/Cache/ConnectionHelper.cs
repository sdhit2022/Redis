using StackExchange.Redis;

namespace Redis.SQL.Cache
{
    public class ConnectionHelper
    {
        static ConnectionHelper()
        {
            var c = System.Configuration.ConfigurationManager.AppSettings["RedisURL"];
            ConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                return ConnectionMultiplexer.Connect("127.0.0.1:6379");
            });
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
