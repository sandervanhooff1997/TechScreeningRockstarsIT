using System.Threading.Tasks;
using Application.Artists.Commands.CreateArtist;
using Application.Artists.Commands.DeleteArtist;
using Application.Artists.Commands.UpdateArtist;
using Application.Artists.Queries.GetArtistsByName;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ArtistsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ArtistDto>> GetArtistByName([FromQuery] GetArtistByNameQuery query)
        {
            var artist = await Mediator.Send(query);

            if (artist == null)
                return NotFound();

            return artist;
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateArtistCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateArtistCommand command)
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
            await Mediator.Send(new DeleteArtistCommand() { Id = id });

            return NoContent();
        }
    }
}