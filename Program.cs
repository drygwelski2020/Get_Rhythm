
// P - Problem is to make an application to track bands, albums, and songs.
//
//Create an application that allows us to:
//
// - Display all bands in the database, as well as all the albums and songs.
// - Allow a user to add a band, album, or song to the database.
// - Allow a user to remove a band, album, or song from a PostGreSQL database.
// - Allow a user to change information about a band, album, or song.
// - Quit the application
//
// - The changes to the database should be saved through the application
//
// D - Data
// 
// Database to interact with the application
// Band class 
//	- Name, CountryOfOrigin, NumberOfMembers, Website, Style, IsSigned, ContactName, ContactPhoneNumber
// Album class
//	- Title, IsExplicit, ReleaseDate, BandId (FK)
// Song class
//	- Title, BandId (FK), AlbumId (FK)
// Context class in order for the application to interact with the PostGreSQL database
//
//
// E - Examples
//
// |    Name     |  CountryOfOrigin  | NumberOfMembers | Website            |  Style   | IsSigned | ContactName          | ContactPhoneNumber |
// | ----------  |  ---------------- | --------------- | ------------------ | -------- | -------- | -------------------- | ------------------ |
// | Aerosmith   |  USA		     |	    5	       | www.aerosmith.com  |  Rock    |   Yes    | Jack Douglas         |    212-555-1212    |
// | Keith Urban |  Australia	     |	    1	       | www.keithurban.com |  Country |   Yes    | Borman Entertainment |    313-555-1414    |
//
//
// User can display band information
// User can add a band to the database
// User can remove a band from the database
// User can display album information
// User can add an album to the database
// User can remove an album from the database
// User can display song information
// User can add a song to the database
// User can remove a song from the database
// User can determine which band recorded an album
// User can determine which song is on a particular album
// User can quit the application
//
// A - Algorithm
//
// Welcome the user to the application
//
// While the user hasn't quit the application:
//
// Display all current info from the database

// Display a menu of options they can do
// 
//Add a new band
//View all the bands
//Add an album for a band
//Let a band go (update isSigned to false)
//Resign a band (update isSigned to true)
//Prompt for a band name and view all their albums
//View all albums ordered by ReleaseDate
//View all bands that are signed
//View all bands that are not signed
// (Q)uit the application
//
// Prompt for their choice
// Based their choice, do that function
//
// - If the user entered quit, then Quit the application
//  End the while loop

using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Get_Rhythm
{
    class Program
    {
        public static void Menu()
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("  Welcome to the Band Information Program     ");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("(AB) Add a new band");
            Console.WriteLine("(VB) View all the bands");
            Console.WriteLine("(AA) Add an album for a band");
            Console.WriteLine("(DB) Let a band go (update isSigned to false)");
            Console.WriteLine("(RB) Re-sign a band (update isSigned to true)");
            Console.WriteLine("(VA) Prompt for a band name and view all their albums");
            Console.WriteLine("(VAR) View all albums ordered by ReleaseDate");
            Console.WriteLine("(VBS) View all bands that are signed");
            Console.WriteLine("(VBN) View all bands that are not signed");
            Console.WriteLine("(Q)uit the application");
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {

            // create a variable to use in order to access our database
            var context = new Get_RhythmContext();

            // Get a reference to our band table
            var bands = context.Band;

            var albums = context.Album.
                // Provide access to the Band table
                Include(album => album.Band);
            // Provide access to the Song table
            var songs = context.Song.
                // add in the Album table
                Include(song => song.Album);

            Menu();

            // Set initial value for the 'choice' variable
            string choice = "";

            // Loop through the user's selections and perform actions based on those selections
            while (choice != "Q")
            {

                Console.Write("Please enter your choice: ");
                choice = Console.ReadLine();

                // Switch statement to determine action(s) to take based on user input
                switch (choice)
                {

                    // Add a new Band
                    case "AB":
                        {
                            Console.Write("Enter band name: ");
                            string Name = Console.ReadLine();
                            Console.Write("Enter Country of Origin: ");
                            string CountryOfOrigin = Console.ReadLine();
                            Console.Write("Enter number of members: ");
                            int NumberOfMembers = Int32.Parse(Console.ReadLine());
                            Console.Write("Enter website: ");
                            string Website = Console.ReadLine();
                            Console.Write("Enter the music style: ");
                            string Style = Console.ReadLine();
                            Console.Write("Is the band currently signed? (true/false) ");
                            Boolean IsSigned = Boolean.Parse(Console.ReadLine());
                            Console.Write("Enter Contact Name: ");
                            string ContactName = Console.ReadLine();
                            Console.Write("Enter Contact Phone Number: ");
                            string ContactPhoneNumber = Console.ReadLine();

                            var newBand = new Band
                            {
                                Name = Name,
                                CountryOfOrigin = CountryOfOrigin,
                                NumberOfMembers = NumberOfMembers,
                                Website = Website,
                                Style = Style,
                                IsSigned = IsSigned,
                                ContactName = ContactName,
                                ContactPhoneNumber = ContactPhoneNumber
                            };

                            //Add the Band to the database
                            context.Band.Add(newBand);
                            context.SaveChanges();
                        };
                        break;

                    // View all Bands
                    case "VB":
                        {
                            foreach (var band in bands)
                            {
                                Console.WriteLine($"Band: {band.Name}");
                            }
                            break;
                        }

                    // Add an Album for a Band
                    case "AA":
                        {
                            Console.Write("Enter album title: ");
                            string Title = Console.ReadLine();
                            Console.Write("Explicit lyrics? (true/false): ");
                            Boolean IsExplicit = Boolean.Parse(Console.ReadLine());
                            Console.Write("Enter release date: ");
                            DateTime ReleaseDate = DateTime.Parse(Console.ReadLine());
                            foreach (var band in bands)
                            {
                                Console.WriteLine($"{band.Id} : {band.Name}");
                            }
                            Console.Write("Enter Band ID associated with the album: ");
                            int BandId = Int32.Parse(Console.ReadLine());

                            var newAlbum = new Album
                            {
                                Title = Title,
                                IsExplicit = IsExplicit,
                                ReleaseDate = ReleaseDate,
                                BandId = BandId,
                            };

                            //Add the Band to the database
                            context.Album.Add(newAlbum);
                            context.SaveChanges();
                        }
                        break;

                    // Let a Band go (update isSigned to false)
                    case "DB":
                        {
                            foreach (var band in bands)
                            {
                                Console.WriteLine($"{band.Id} : {band.Name}");
                            }
                            Console.Write("Enter Band Id: ");
                            var bandToLetGo = Int32.Parse(Console.ReadLine());
                            var bandInfo = context.Band.Find(bandToLetGo);
                            bandInfo.IsSigned = false;
                            context.Entry(bandInfo).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        break;

                    // Re-sign a Band (update isSigned to true)
                    case "RB":
                        {
                            foreach (var band in bands)
                            {
                                Console.WriteLine($"{band.Id} : {band.Name}");
                            }
                            Console.Write("Enter Band Id: ");
                            var bandToResign = Int32.Parse(Console.ReadLine());
                            var bandInfo = context.Band.Find(bandToResign);
                            bandInfo.IsSigned = true;
                            context.Entry(bandInfo).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        break;

                    // Prompt for Band and show all their Albums
                    case "VA":
                        {
                            foreach (var band in bands)
                            {
                                Console.WriteLine($"{band.Id} : {band.Name}");
                            }

                            Console.Write("Enter Band Id: ");
                            var bandNum = Int32.Parse(Console.ReadLine());
                            var bandInfo = context.Band.Find(bandNum);
                            Console.WriteLine($"Band Name: {bandInfo.Name}");
                            Console.WriteLine($"Band Id: {bandInfo.Id}");

                            var records = context.Album.Where(b => b.BandId == b.Band.Id);

                            foreach (var record in records)
                            {
                                if (record.BandId == bandNum)
                                {
                                    Console.WriteLine($"Album: {record.Title}");
                                    continue;
                                }

                            }
                        }
                        break;

                    // View all Albums ordered by Release Date
                    case "VAR":
                        {
                            foreach (var album in albums)
                            {
                                Console.WriteLine(album.Title);
                            }
                            break;
                        }

                    // View all Bands that are signed (isSigned == true)
                    case "VBS":
                        {
                            foreach (var band in bands)
                            {
                                if (band.IsSigned == true)
                                {
                                    Console.WriteLine(band.Name);
                                }
                            }
                            break;
                        }

                    // View all Bands that are not signed (isSigned == false)
                    case "VBN":
                        {
                            foreach (var band in bands)
                            {
                                if (band.IsSigned == false)
                                {
                                    Console.WriteLine(band.Name);
                                }
                            }
                            break;
                        }

                    case "Q":
                        break;
                }

            }
        }
    }
}
