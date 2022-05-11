using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Artists.Commands.DeleteArtist
{
    public class DeleteArtistCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteArtistCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Artists
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Artist), request.Id);
            }

            _context.Artists.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}