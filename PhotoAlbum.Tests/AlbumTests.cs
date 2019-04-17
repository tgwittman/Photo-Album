using Xunit;
using Moq;
using System.Collections.Generic;
using System.Text;

namespace PhotoAlbum.Tests
{
    public class AlbumTests
    {
        readonly List<Models.Photo> photos = new List<Models.Photo>();
        Mock<IAlbumService> albumServiceMock = new Mock<IAlbumService>();

        public AlbumTests()
        {
            photos = new List<Models.Photo>
            {
                new Models.Photo {
                    Id = 1,
                    AlbumId = 1,
                    Title = "Title",
                    ThumbnailUrl = "https://via.placeholder.com/150/92bfbf",
                    Url = "https://via.placeholder.com/600/92bfbf"
                },
                new Models.Photo {
                    Id = 2,
                    AlbumId = 1,
                    Title = "Title2",
                    ThumbnailUrl = "https://via.placeholder.com/150/92bfbf",
                    Url = "https://via.placeholder.com/600/92bfbf"
                }
            };

            albumServiceMock.Setup(_ => _.RetrieveAsync(It.IsAny<int>())).ReturnsAsync(photos);
        }

        [Fact]
        public void When_Populate_AllPhotosReturned()
        {
            //Act
            var album = new Album(albumServiceMock.Object);
            var results = album.Populate(photos[0].AlbumId);

            //Assert
            Assert.Equal(results, photos);
        }

        [Fact]
        public void When_Photos_ValidPrintMessage()
        {
            //Arrange
            var expected = new StringBuilder();
            foreach (var photo in photos)
            {
                expected.AppendLine($"[{photo.Id}] {photo.Title}");
            }

            //Act
            var album = new Album(albumServiceMock.Object);
            var results = album.PrintMessage(photos);

            //Assert
            Assert.Equal(results, expected.ToString());
        }

        [Fact]
        public void When_NoPhotos_InValidPrintMessage()
        {
            //Arrange
            var emptyPhotos = new List<Models.Photo>();
            var expected = new StringBuilder().AppendLine("No photos found.");
            var emptyAlbumServiceMock = new Mock<IAlbumService>();
            emptyAlbumServiceMock.Setup(_ => _.RetrieveAsync(It.IsAny<int>())).ReturnsAsync(emptyPhotos);

            //Act
            var album = new Album(emptyAlbumServiceMock.Object);
            var results = album.PrintMessage(emptyPhotos);

            //Assert
            Assert.Equal(results, expected.ToString());
        }
    }
}
