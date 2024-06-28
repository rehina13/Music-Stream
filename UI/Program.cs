using System;
using System.Collections.Generic;
using MusicPlaylistDL;
using PlaylistSongBL;

namespace UI
{
    public class MusicInfo
    {
        public string Artist { get; set; }
        public string SongsAndAlbum { get; set; }
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

    public class MusicOperator
    {
        private List<MusicInfo> infos;
        private SqlDBData sqlData;

        public MusicOperator()
        {
            infos = new List<MusicInfo>();
            sqlData = new SqlDBData();
        }

        public List<MusicInfo> GetMusicInfos()
        {
            infos = sqlData.GetMusicInfos();
            return infos;
        }

        public int AddMusicInfo(MusicInfo info)
        {
            return sqlData.AddMusicInfo(info.Artist, info.SongsAndAlbum);
        }

        public int UpdateMusicInfo(MusicInfo info)
        {
            return sqlData.UpdateMusicInfo(info.Artist, info.SongsAndAlbum);
        }

        public int DeleteMusicInfo(MusicInfo info)
        {
            return sqlData.DeleteMusicInfo(info.Artist);
        }
    }

    public class SqlDBData
    {
        public List<MusicInfo> GetMusicInfos()
        {
            return new List<MusicInfo>();
        }

        public int AddMusicInfo(string artist, string songsAndAlbum)
        {
            return 1;
        }

        public int UpdateMusicInfo(string artist, string songsAndAlbum)
        {
            return 1;
        }

        public int DeleteMusicInfo(string artist)
        {
            return 1;
        }
    }
}
