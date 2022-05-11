using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Songs.Queries.GetSongsByGenre;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Artists.Queries.GetArtistsByName
{
    public class GetSongsByGenreQuery: IRequest<IEnumerable<SongDto>>
    {
        public string Genre { get; set; }
    }
    
    public class GetSongsByGenreQueryHandler : IRequestHandler<GetSongsByGenreQuery, IEnumerable<SongDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSongsByGenreQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SongDto>> Handle(GetSongsByGenreQuery request, CancellationToken cancellationToken)
        {
            return await _context.Songs
                .Where(a => a.Genre == request.Genre)
                .ProjectTo<SongDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}