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
            if (users == null || users.Count == 0)
            {
                return NotFound(new { Message = "No music information found." });
            }
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.username) || string.IsNullOrEmpty(user.Artist) || string.IsNullOrEmpty(user.SongsAndAlbum))
            {
                return BadRequest(new { Message = "Invalid user data." });
            }
            _sqlData.AddMusicInfo(user.username, user.Artist, user.SongsAndAlbum);
            return Ok(new { Message = "Music information added successfully." });
        }

        [HttpPatch("{artist}")]
        public IActionResult Patch(string artist, [FromBody] User user)
        {
            if (string.IsNullOrEmpty(artist) || user == null)
            {
                return BadRequest(new { Message = "Invalid input data." });
            }
            User oldUser = new User { Artist = artist };
            _sqlData.UpdateMusicInfo(oldUser, user);
            return Ok(new { Message = "Music information updated successfully." });
        }

        [HttpDelete("{artist}")]
        public IActionResult Delete(string artist)
        {
            if (string.IsNullOrEmpty(artist))
            {
                return BadRequest(new { Message = "Artist name is required." });
            }
            _sqlData.DeleteMusicInfo(artist);
            return Ok(new { Message = "Music information deleted successfully." });
        }
    }
}
