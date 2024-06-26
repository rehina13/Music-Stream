using MusicPlaylistDL;

namespace PlaylistSongBL
{
    public class PlaylistSong
    {
        public static void FindAndDisplaySongs(string artistName, Dictionary<string, (string Album, string[] Songs)> artistSongs)
        {
            bool artistFound = false;

            foreach (var artist in artistSongs)
            {
                if (artist.Key.Equals(artistName, StringComparison.OrdinalIgnoreCase))
                {
                    artistFound = true;
                    DisplaySongs(artistName, artist.Value.Album, artist.Value.Songs);
                    break;
                }
            }

            if (!artistFound)
            {
                Console.WriteLine($"Artist '{artistName}' not found.");
            }
        }

        public static void DisplaySongs(string artistName, string album, string[] songs)
        {
            Console.WriteLine($"\nSongs by {artistName} from the album {album}:");
            foreach (var song in songs)
            {
                Console.WriteLine($"- {song}");
            }
        }
    }
}