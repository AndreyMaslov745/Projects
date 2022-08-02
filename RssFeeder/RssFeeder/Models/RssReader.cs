using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Http.Headers;
using RssFeeder.Models.Common;
namespace RssFeeder.Models
{
    public class RssReader
    {
        public static IEnumerable<Feed> GetRssFeed(ConnectionManager manager)
        {

                HttpResponseMessage response = GetResponse(manager);
                XDocument feedXml = XDocument.Parse(response.Content.ReadAsStringAsync().Result);
                var feed = feedXml.Descendants("item").Select(x => new Feed()
                { Title = x.Element("title").Value, Link = x.Element("link").Value, PubDate = x.Element("pubDate").Value, Description = Regex.Replace(x.Element("description").Value, "<.*?>", String.Empty) });
                return feed;
        }
        public static HttpResponseMessage GetResponse(ConnectionManager manager)
        {
            WebProxy proxy = new WebProxy();
            proxy.Address = new Uri(manager.ProxyAddres);
            proxy.Credentials = new NetworkCredential(manager.ProxyLogin, manager.ProxyPassword);
            proxy.BypassProxyOnLocal = false;
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.Proxy = proxy;
                handler.UseProxy = true;
                handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var client = new HttpClient(handler);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = client.GetAsync(manager.FeedUrl).Result;
                return response;
            }
        }
    }
}

