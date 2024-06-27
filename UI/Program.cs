using System;
using System.Collections.Generic;
using MusicPlaylistDL;

namespace UI
{
    public class MusicInfo
    {
        public string Artist { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<User> usersFROMDB = SqlData.GetUsers();

            Console.WriteLine("Welcome to Your Music Stream Choice!");

            // Please enter your username once you login.
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();

            Console.WriteLine($"Hello, {username}! Please enter your Artist Choice.");

            MusicInfo musicInfo = new MusicInfo();

            Console.WriteLine("Enter artist:");
            musicInfo.Artist = Console.ReadLine();

            Console.WriteLine("\nYour music stream choice is already done.");

            Console.WriteLine("\nMusic Information:");

            Dictionary<string, (string Album, string[] Songs)> artistSongs = InitializeArtistSongs();

            FindAndDisplaySongs(musicInfo.Artist, artistSongs);

            Console.ReadLine();
        }

        public static Dictionary<string, (string Album, string[] Songs)> InitializeArtistSongs()
        {
            return new Dictionary<string, (string Album, string[] Songs)>
            {
                { "Artist1", ("Album1", new string[] { "Song1", "Song2" }) },
                { "Artist2", ("Album2", new string[] { "Song3", "Song4" }) }
            };
        }

        public static void FindAndDisplaySongs(string artist, Dictionary<string, (string Album, string[] Songs)> artistSongs)
        {
            if (artistSongs.ContainsKey(artist))
            {
                var info = artistSongs[artist];
                Console.WriteLine($"Artist: {artist}");
                Console.WriteLine($"Album: {info.Album}");
                Console.WriteLine("Songs:");
                foreach (var song in info.Songs)
                {
                    Console.WriteLine($"- {song}");
                }
            }
            else
            {
                Console.WriteLine("Artist not found.");
            }
        }
    }
}

