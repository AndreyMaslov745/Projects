using System.Xml.Serialization;
namespace RssFeeder.Models.Common
{ 
    public class ConnectionManager
    {
        public string? FeedUrl { get; init; }
        public string? ProxyAddres { get; init; }
        public string? ProxyLogin { get; init; }
        public string? ProxyPassword { get; init; }
        public string? UpdateTime { get; init; }

        public ConnectionManager(string? feedUrl, string? proxyAddres, string? proxyLogin, string? proxyPassword, string? updatetime)
        {
            FeedUrl = feedUrl;
            ProxyAddres = proxyAddres;
            ProxyLogin = proxyLogin;
            ProxyPassword = proxyPassword;
            UpdateTime = updatetime;
        }

        public static ConnectionManager? XmlDesirializer(string config_path)
        {
            using (StreamReader reader = new(new FileStream(config_path, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConnectionManager), new XmlRootAttribute("Connection"));
                ConnectionManager? connectionManager = serializer.Deserialize(reader) as ConnectionManager;
                return connectionManager;
            }
        }
        public ConnectionManager()
        {

        }
    }
}
