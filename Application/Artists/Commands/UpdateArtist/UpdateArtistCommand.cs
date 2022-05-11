using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Artists.Commands.UpdateArtist
{
    public class UpdateArtistCommand : IRequest
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }

    public class UpdateArtistCommandHandler : IRequestHandler<UpdateArtistCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateArtistCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Artists.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Artist), request.Id);
            }

            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}