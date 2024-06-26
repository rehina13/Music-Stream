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

            Console.WriteLine("Hello, {username}! Please enter your Artist Choice.");

            MusicInfo musicInfo = new MusicInfo();

            Console.WriteLine("Enter artist:");
            musicInfo.Artist = Console.ReadLine();

            Console.WriteLine("\nYour music stream choice is already done.");
            
            Console.WriteLine("\nMusic Information:");


            // Initialize artist songs
            Dictionary<string, (string Album, string[] Songs)> artistSongs = ArtistSong.InitializeArtistSongs();

            // Find and display songs by the entered artist
            PlaylistSong.FindAndDisplaySongs(musicInfo.Artist, artistSongs);



            Console.ReadLine();
        }
    }
}
