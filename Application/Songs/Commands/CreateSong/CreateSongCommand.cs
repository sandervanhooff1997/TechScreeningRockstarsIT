using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Songs.Commands.CreateSong
{
    public class CreateSongCommand : IRequest<int>
    { 
        public string Name { get; set; }

        public int Year { get; set; }

        public string Artist { get; set; }
        
        public string Shortname { get; set; }
        
        public int? Bpm { get; set; }
        
        public int Duration { get; set; }
        
        public string Genre { get; set; }
        
        public string SpotifyId { get; set; }
        
        public string Album { get; set; }
    }

    public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateSongCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSongCommand request, CancellationToken cancellationToken)
        {
            var entity = new Song
            {
                Name = request.Name,
                Year = request.Year,
                Artist = request.Artist,
                Shortname = request.Shortname,
                Bpm = request.Bpm,
                Duration = request.Duration,
                Genre = request.Genre,
                SpotifyId = request.SpotifyId,
                Album = request.Album
            };
            
            _context.Songs.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }

}