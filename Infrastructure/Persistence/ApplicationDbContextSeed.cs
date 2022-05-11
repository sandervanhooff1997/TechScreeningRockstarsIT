using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Files.FileReader;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// Seed database with static JSON files.
    /// </summary>
    public class ApplicationDbContextSeed
    {
        private static readonly string ArtistsFilePath =
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty,
                @"Files\artists.json");

        private static readonly string SongsFilePath =
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty,
                @"Files\songs.json");

        public static async Task SeedData(ApplicationDbContext context)
        {
            if (context.Artists.Any() && context.Artists.Any())
                return;

            var fileReader = new JsonFileReader();
            
            // Read JSON songs.
            var songs = fileReader.ReadAndDeserialize<IEnumerable<Song>>(SongsFilePath);
            
            // Filter songs before 2016 and with a valid Id value.
            songs = songs.Where(s => s.Id != 0 && s.Year < 2016);

            // Read JSON artists
            var artists = fileReader.ReadAndDeserialize<IEnumerable<Artist>>(ArtistsFilePath);
            
            // Filter artists that have Metal songs and a valid Id value. 
            artists = artists.Where(a => a.Id != 0 && songs.Any(s => s.Artist == a.Name && s.Genre == "Metal"));

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Songs;");
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Songs ON;");
                context.Songs.AddRange(songs);
                await context.SaveChangesAsync();

                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Songs OFF;");
                await transaction.CommitAsync();
            }

            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE dbo.Artists;");
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Artists ON;");
                context.Artists.AddRange(artists);
                await context.SaveChangesAsync();
                
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Artists OFF;");
                await transaction.CommitAsync();
            }
        }
    }
}