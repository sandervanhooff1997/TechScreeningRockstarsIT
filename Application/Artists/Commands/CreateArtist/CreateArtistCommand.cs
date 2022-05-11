using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Artists.Commands.CreateArtist
{
    public class CreateArtistCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateArtistCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var entity = new Artist
            {
                Name = request.Name
            };
            
            _context.Artists.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }

}