using System;
using System.Collections.Generic;

namespace PhotoAlbum
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1 && int.TryParse(args[0], out int result))
            {
                IAlbumService albumService = new AlbumService();

                IAlbum album = new Album(albumService);

                List<Models.Photo> photos = album.Populate(result);
                var message = album.PrintMessage(photos);

                Console.Write(message);
            }
            else
            {
                Console.WriteLine("Argument '" + args[0] + "' is invalid. Please choose an integer from 1-100.");
            }
        }
    }
}