using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Artists.Commands.DeleteArtist
{
    public class DeleteSongCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteSongCommandHandler : IRequestHandler<DeleteSongCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSongCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSongCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Songs
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Song), request.Id);
            }

            _context.Songs.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}