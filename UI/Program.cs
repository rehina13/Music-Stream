using System;
using System.Collections.Generic;
using Model;
using MusicPlaylistDL;
using MailKit.Net.Smtp;
using MimeKit;

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

            SendEmail("Music Added", $"New music by {artist} has been added by {username}.");
        }

        static void UpdateMusicInfo(SqlData sqlData, string username)
        {
            Console.WriteLine("Enter artist to update:");
            string artist = Console.ReadLine();
            Console.WriteLine("Enter new artist:");
            string newArtist = Console.ReadLine();
            Console.WriteLine("Enter new songs and album:");
            string newSongsAndAlbum = Console.ReadLine();

            sqlData.UpdateMusicInfo(new User { Artist = artist, SongsAndAlbum = newSongsAndAlbum }, new User { Artist = newArtist, SongsAndAlbum = newSongsAndAlbum });
            Console.WriteLine("Music info updated successfully.");

            SendEmail("Music Updated", $"Music by {artist} has been updated to {newArtist} by {username}.");
        }

        static void DeleteMusicInfo(SqlData sqlData)
        {
            Console.WriteLine("Enter artist to delete:");
            string artist = Console.ReadLine();

            sqlData.DeleteMusicInfo(artist);
            Console.WriteLine("Music info deleted successfully.");

            SendEmail("Music Deleted", $"Music by {artist} has been deleted.");
        }

        static void ViewMusicInfo(SqlData sqlData)
        {
            List<User> users = SqlData.GetMusicInfo();

            Console.WriteLine("\nMusic Information:");
            foreach (User user in users)
            {
                Console.WriteLine($"Artist: {user.Artist}, Songs and Album: {user.SongsAndAlbum}");
            }

            SendEmail("Music Viewed", "Music info has been viewed.");
        }

        public static void SendEmail(string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("FromMyNotes", "do-not-reply@frommynotes.com"));
            message.To.Add(new MailboxAddress("Regine Cequena", "cequenaregine@gmail.com"));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = $"<h1>{subject}</h1><p>{body}</p>"  
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("08e4c63d244a25", "99fbae344e73e5");
                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
