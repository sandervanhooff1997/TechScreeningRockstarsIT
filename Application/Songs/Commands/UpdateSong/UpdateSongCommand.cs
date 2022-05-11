using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Songs.Commands.UpdateSong
{
    public class UpdateSongCommand : IRequest
    {
        public int Id { get; set; }
        
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

    public class UpdateSongCommandHandler : IRequestHandler<UpdateSongCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSongCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSongCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Songs.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Song), request.Id);
            }

            entity.Name = request.Name;
            entity.Year = request.Year;
            entity.Artist = request.Artist;
            entity.Shortname = request.Shortname;
            entity.Bpm = request.Bpm;
            entity.Duration = request.Duration;
            entity.Genre = request.Genre;
            entity.SpotifyId = request.SpotifyId;
            entity.Album = request.Album;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}