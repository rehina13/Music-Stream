using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylistDL
{
    public class MusicDL
    {
        List<User> users = new List<User>();
        public void AddMusicInfo(User user)
        {
            users.Add(user);
        }
        public List<User> GetMusicInfo()
        {
            return users;
        }
    }
}