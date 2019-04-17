using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using PhotoAlbum.Models;

namespace PhotoAlbum
{
    public class AlbumService : IAlbumService
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static readonly string baseUri = "https://jsonplaceholder.typicode.com/photos";

        public AlbumService()
        {
        }

        public async Task<List<Photo>> RetrieveAsync(int id)
        {
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var serializer = new DataContractJsonSerializer(typeof(List<Photo>));

            try
            {
                var streamTask = HttpClient.GetStreamAsync(baseUri + "?albumId=" + id.ToString());
                return serializer.ReadObject(await streamTask) as List<Photo>;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught Exception {ex.Message}");
            }

            return null;
        }
    }
}
