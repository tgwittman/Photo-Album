using System.Collections.Generic;
using System.Text;
using PhotoAlbum.Models;

namespace PhotoAlbum
{
    public class Album : IAlbum
    {
        private readonly IAlbumService _albumService;

        public Album(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public List<Photo> Populate(int id)
        {
            return _albumService.RetrieveAsync(id).Result;
        }

        public string PrintMessage(List<Photo> Photos)
        {
            var stringBuilder = new StringBuilder();
            if (Photos.Count == 0)
            {
                stringBuilder.AppendLine("No photos found.");
                return stringBuilder.ToString();
            }

            foreach (var photo in Photos)
            {
                stringBuilder.AppendLine($"[{photo.Id}] {photo.Title}");
            }
            return stringBuilder.ToString();
        }
    }
}