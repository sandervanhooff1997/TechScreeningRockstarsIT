using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    /// <summary>
    /// Provides an API for accessing the database context through infrastructure.
    /// </summary>
    public interface IApplicationDbContext
    {
        DbSet<Song> Songs { get; }
        
        DbSet<Artist> Artists { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new ());
    }
}