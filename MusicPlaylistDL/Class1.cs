using Model;

namespace MusicPlaylistDL
{
    public class ArtistSong
    {
        public static Dictionary<string, (string Album, string[] Songs)> InitializeArtistSongs()
        {
            return new Dictionary<string, (string Album, string[] Songs)>
            {
                { "Coldplay", ("A Rush of Blood to the Head", new string[] { "Sparks", "Fix You", "Paradise", "Yellow" }) },
                { "Taylor Swift", ("Red", new string[] { "Slut!", "Sparks Fly", "Blank Space", "You Belong With Me", "All too Well" }) },
                { "Olivia Rodrigo", ("SOUR", new string[] { "Vampire", "Drivers License", "Good 4 u", "Deja vu" }) },
                { "Hev Abi", ("Hev Abi Album", new string[] { "Alam Mo Ba", "Babaero", "Marikit" }) },
                { "Blackpink", ("Blackpink in Your Area", new string[] { "Boombayah", "Forever Young", "Whistle", "Stay" }) },
                { "BTS", ("BE", new string[] { "Magic", "Dynamite", "Spring Day", "Not Today", "Dimple", "Home" }) },
                { "Carpenters", ("Yesterday Once More", new string[] { "Close To You", "Yesterday Once More", "I won't Last A Day", "You" }) },
                { "Moira", ("Patawad", new string[] { "Kumpas", "Dito ka lang", "Babalik Sayo", "Tagpuan" }) }
            };
        }
    }
}
