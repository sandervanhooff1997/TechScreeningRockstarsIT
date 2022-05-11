using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Artists.Queries.GetArtistsByName
{
    public class ArtistDto : IMapFrom<Artist>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}