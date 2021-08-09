using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()

                .HasColumnType("varchar(200)");

            builder
                .HasMany(p => p.Casts)
                .WithMany(p => p.Movies)
                .UsingEntity(j => j.ToTable("CastMovies"));

            builder.ToTable("Movies");
        }
    }
}
