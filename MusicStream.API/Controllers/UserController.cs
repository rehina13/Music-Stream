using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusicPlaylistDL;
using Model;

namespace MusicPlaylistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicInfoController : ControllerBase
    {
        private readonly SqlData _sqlData;

        public MusicInfoController(SqlData sqlData)
        {
            _sqlData = sqlData;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = SqlData.GetMusicInfo();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _sqlData.AddMusicInfo(user.username, user.Artist, user.SongsAndAlbum);
            return Ok();
        }

        [HttpPatch("{artist}")]
        public IActionResult Patch(string artist, [FromBody] User user)
        {
            User oldUser = new User { Artist = artist };
            _sqlData.UpdateMusicInfo(oldUser, user);
            return Ok();
        }

        [HttpDelete("{artist}")]
        public IActionResult Delete(string artist)
        {
            _sqlData.DeleteMusicInfo(artist);
            return Ok();
        }
    }
}
