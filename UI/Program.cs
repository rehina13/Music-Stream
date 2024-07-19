using System;
using System.Collections.Generic;
using Model;
using MusicPlaylistDL;

namespace UI
{
 

    class Program
    {
        static void Main(string[] args)
        {
            SqlData sqlData = new SqlData();
            string username;

            Console.WriteLine("Welcome to Your Music Stream Choice!");

            Console.WriteLine("Please enter your username:");
            username = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Music Info");
                Console.WriteLine("2. Update Music Info");
                Console.WriteLine("3. Delete Music Info");
                Console.WriteLine("4. View Music Info");
                Console.WriteLine("5. Exit");
                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddMusicInfo(sqlData, username);
                        break;
                    case "2":
                        UpdateMusicInfo(sqlData, username);
                        break;
                    case "3":
                        DeleteMusicInfo(sqlData);
                        break;
                    case "4":
                        ViewMusicInfo(sqlData);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddMusicInfo(SqlData sqlData, string username)
        {
            Console.WriteLine("Enter artist:");
            string artist = Console.ReadLine();
            Console.WriteLine("Enter songs and album:");
            string songsAndAlbum = Console.ReadLine();

            sqlData.AddMusicInfo(username, artist, songsAndAlbum);
            Console.WriteLine("Music info added successfully.");
        }

        static void UpdateMusicInfo(SqlData sqlData, string username)
        {
            Console.WriteLine("Enter artist to update:");
            string artist = Console.ReadLine();
            Console.WriteLine("Enter new songs and album:");
            string songsAndAlbum = Console.ReadLine();

            sqlData.DeleteMusicInfo(artist);
            Console.WriteLine("Music info updated successfully.");
        }

        static void DeleteMusicInfo(SqlData sqlData)
        {
            Console.WriteLine("Enter artist to delete:");
            string artist = Console.ReadLine();

            sqlData.DeleteMusicInfo(artist);
            Console.WriteLine("Music info deleted successfully.");
        }

        static void ViewMusicInfo(SqlData sqlData)
        {
            List<User> users = SqlData.GetMusicInfo();

            Console.WriteLine("\nMusic Information:");
            foreach (User user in users)
            {
                Console.WriteLine($"Artist: {user.Artist}, Songs and Album: {user.SongsAndAlbum}");
            }
        }
    }
}
