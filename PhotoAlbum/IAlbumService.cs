using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoAlbum.Models;

namespace PhotoAlbum
{
    public interface IAlbumService
    {
        Task<List<Photo>> RetrieveAsync(int id);
    }
}