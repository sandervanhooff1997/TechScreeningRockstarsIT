using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Artists.Queries.GetArtistsByName
{
    public class GetArtistByNameQuery: IRequest<ArtistDto>
    {
        public string Name { get; set; }
    }
    
    public class GetArtistByNameQueryHandler : IRequestHandler<GetArtistByNameQuery, ArtistDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetArtistByNameQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ArtistDto> Handle(GetArtistByNameQuery request, CancellationToken cancellationToken)
        {
            return await _context.Artists
                .Where(a => a.Name == request.Name)
                .ProjectTo<ArtistDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}