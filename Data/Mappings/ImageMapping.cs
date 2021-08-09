using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class ImageMapping : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.UrlImage)
              .IsRequired()
              .HasColumnType("varchar(1000)");

            builder.ToTable("Images");
        }
    }
}
