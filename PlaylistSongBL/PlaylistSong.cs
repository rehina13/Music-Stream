using System.Collections.Generic;
using Model;
using MusicPlaylistDL;

namespace PlaylistSongBL
{
    public class PlaylistSong
    {
        private readonly SqlData _dataService;

        public PlaylistSong()
        {
            _dataService = new SqlData();
        }

        public List<User> GetMusicInfo()
        {
            return SqlData.GetMusicInfo();
        }

        public void AddMusicInfo(string username, string artist, string songsAndAlbum)
        {
            _dataService.AddMusicInfo(username, artist, songsAndAlbum);
        }

        public void DeleteMusicInfo(string artist)
        {
            _dataService.DeleteMusicInfo(artist);
        }

        public void UpdateMusicInfo(string oldArtist, string oldSongsAndAlbum, string newArtist, string newSongsAndAlbum)
        {
            User oldUser = new User { Artist = oldArtist, SongsAndAlbum = oldSongsAndAlbum };
            User newUser = new User { Artist = newArtist, SongsAndAlbum = newSongsAndAlbum };
            _dataService.UpdateMusicInfo(oldUser, newUser);
        }
    }
}
