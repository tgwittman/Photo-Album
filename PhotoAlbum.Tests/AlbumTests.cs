using Xunit;
using Moq;
using System.Collections.Generic;

namespace PhotoAlbum.Tests
{
    public class AlbumTests
    {
        [Fact]
        public void When_Populate_AllPhotosReturned()
        {
            //Arrange
            var photos = new List<Models.Photo>
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

            var albumServiceMock = new Mock<IAlbumService>();
            albumServiceMock.Setup(_ => _.RetrieveAsync(It.IsAny<int>())).ReturnsAsync(photos);

            //Act
            var album = new Album(albumServiceMock.Object);
            var results = album.Populate(photos[0].AlbumId);

            //Assert
            Assert.Equal(results, photos);
        }
    }
}
