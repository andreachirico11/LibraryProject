using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBackend.Models;

namespace NewBackend
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres", "db");
            builder.HasKey(g => g.IdGenre);
            builder.Property(g => g.IdGenre)
                    .HasColumnType("int")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            builder.Property(g => g.Name)
                    .HasColumnType("varchar")
                    .HasMaxLength(20);
        }
    }
}