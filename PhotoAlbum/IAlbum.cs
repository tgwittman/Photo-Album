using System.Collections.Generic;
using PhotoAlbum.Models;

namespace PhotoAlbum
{
    public interface IAlbum
    {
        List<Photo> Populate(int id);

        string PrintMessage(List<Photo> Photos);
    }
}