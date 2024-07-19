using MusicPlaylistDL;
using Model;

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
            return _dataService.GetMusicInfo();
        }

        public void AddMusicInfo(string username, string Artist, string songsAndAlbum)
        {
            _dataService.AddMusicInfo(new User { username = username, Artist = Artist, SongsAndAlbum = songsAndAlbum });
        }

        public void DeleteMusicInfo(string username, string Artist, string SongsAndAlbum)
        {
            _dataService.DeleteSong(username, Artist, SongsAndAlbum);
        }

        public void UpdateMusicInfo(string oldArtist, string oldSongsAndALbum, string newArtist, string newSongsAndAlbum)
        {
            _dataService.UpdateMusicInfo(new User { Artist = oldArtist, SongsAndAlbum = oldSongsAndALbum }, new User { Artist = newArtist, SongsAndAlbum = newSongsAndAlbum });
        }
    }        
}