using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired();
            
            builder.Property(a => a.Year)
                .IsRequired();
            
            builder.Property(a => a.Artist)
                .IsRequired();
            
            builder.Property(a => a.Shortname)
                .IsRequired();
            
            builder.Property(a => a.Duration)
                .IsRequired();
            
            builder.Property(a => a.Genre)
                .IsRequired();
        }
    }
}