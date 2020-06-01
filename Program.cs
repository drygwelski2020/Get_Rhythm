using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Get_Rhythm
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a variable to use in order to access our database
            var context = new Get_RhythmContext();

            // Get a reference to our band table
            var bands = context.Band;
            var albums = context.Album.Include(album => album.Band);
            // Provide access to the Song table
            var songs = context.Song.
                        // add in the Band table
                        Include(song => song.Band).
                        // add in the Album table
                        Include(song => song.Album);

            var bandCount = bands.Count();
            Console.WriteLine($"\nThere are {bandCount} bands in our current list.\n");

            foreach (var band in bands)
            {
                Console.WriteLine($"A band in the list is {band.Name}");
            }
            foreach (var album in albums)
            {
                Console.WriteLine($"One band id is {album.Band.Id}");
            }
            foreach (var song in songs)
            {
                Console.WriteLine($"A song would be {song.Title} and the album would be {song.Album.Title}");
            }

            Console.WriteLine();


            // TO ADD AN ENTRY TO THE DATABASE /////////////
            //  var newAlbum = new Album
            //  {
            //      Title = "I Walk The Line",
            //      IsExplicit = false,
            //    ReleaseDate = "07-01-1964".ToString(),
            //     BandId = 2,
            //  };

            // Add the new ALbum to the database
            //   context.Album.Add(newAlbum);

            // Save the changes to the database
            // context.SaveChanges();

            // TO CHANGE AN ENTRY IN THE DATABASE /////////////
            // var existingAlbum = context.Album.FirstOrDefault(album => album.Title == "I Walk The Line");
            // if (existingAlbum != null)
            // {
            //     existingAlbum.IsExplicit = true;
            //     context.Entry(existingAlbum).State = EntityState.Modified;
            //      context.SaveChanges();
            //  }

            // TO REMOVE AN ENTRY FROM THE DATABASE ////////////
            // var existingAlbumToDelete = context.Album.FirstOrDefault(album => album.Title == "I Walk The Line");
            // if (existingAlbumToDelete != null)
            // {
            //     context.Album.Remove(existingAlbumToDelete);
            //      context.SaveChanges();
            //  }

        }
    }
}
