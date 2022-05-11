using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Artists.Commands.DeleteArtist;
using Application.Artists.Queries.GetArtistsByName;
using Application.Songs.Commands.CreateSong;
using Application.Songs.Commands.UpdateSong;
using Application.Songs.Queries.GetSongsByGenre;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class SongsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<SongDto>> GetSongsByGenre([FromQuery] GetSongsByGenreQuery query)
        {
            return await Mediator.Send(query);
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSongCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateSongCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteSongCommand() { Id = id });

            return NoContent();
        }
    }
}