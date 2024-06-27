using System;
using System.Collections.Generic;
using MusicPlaylistDL;
using PlaylistSongBL;

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
            Console.WriteLine("Welcome to Your Music Stream Choice!");

            // User login process
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();

            Console.WriteLine($"Hello, {username}! Please enter your music preferences.");

            MusicInfo musicInfo = new MusicInfo();

            Console.WriteLine("Enter artist:");
            musicInfo.Artist = Console.ReadLine();

            Console.WriteLine("\nMusic Information:");
            Console.WriteLine($"Artist: {musicInfo.Artist}");

            Console.WriteLine("\nYour music stream choice is already done.");

            Dictionary<string, (string Album, string[] Songs)> artistSongs = ArtistSong.InitializeArtistSongs();

           
            PlaylistSong.FindAndDisplaySongs(musicInfo.Artist, artistSongs);

            Console.ReadLine();
        }
    }
}