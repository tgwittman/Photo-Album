using System.Net.Http;
using System.Net.Http.Headers;

namespace PhotoAlbum
{
    public class Client
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        public string Url { get; set; }

        public Client(string url)
        {
            Url = url;
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
