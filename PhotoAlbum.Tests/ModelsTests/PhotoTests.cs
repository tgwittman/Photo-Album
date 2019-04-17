using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using PhotoAlbum.Models;
using Xunit;

namespace PhotoAlbum.Tests.ModelsTests
{
    public class PhotoTests
    {
        [Fact]
        public void When_NewPhoto_JsonSerializerPerformsCorrectly()
        {
            //Arrange
            var photo = new Photo
            {
                Id = 1,
                AlbumId = 1,
                Title = "Title",
                ThumbnailUrl = "https://via.placeholder.com/150/92bfbf",
                Url = "https://via.placeholder.com/600/92bfbf"
            };
            string jsonstring = "{\n    \"albumId\": 1,\n    \"id\": 1,\n    \"title\": \"Title\",\n    \"url\": \"https://via.placeholder.com/600/92bfbf\",\n    \"thumbnailUrl\": \"https://via.placeholder.com/150/92bfbf\"\n  }";

            //Act
            var actual = new Photo();
            var serializer = new DataContractJsonSerializer(typeof(Photo));
            using (var test_stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonstring)))
            {
                actual = serializer.ReadObject(test_stream) as Photo;
            }

            //Assert
            Assert.Equal(photo.Id, actual.Id);
            Assert.Equal(photo.AlbumId, actual.AlbumId);
            Assert.Equal(photo.Title, actual.Title);
            Assert.Equal(photo.ThumbnailUrl, actual.ThumbnailUrl);
            Assert.Equal(photo.Url, actual.Url);
        }
    }
}
