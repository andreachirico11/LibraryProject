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
                    .HasColumnType("varchar(20)");

            builder.HasMany(gen => gen.Books)
                    .WithOne(book => book.Genre)
                    .HasForeignKey(Book => Book.IdGenre);
        
            builder.HasData(new Genre(1, "Fantasy"));
            builder.HasData(new Genre(2, "Storico"));
            builder.HasData(new Genre(3, "Saggistica"));
            builder.HasData(new Genre(4, "Informatica"));
            builder.HasData(new Genre(5, "Diritto"));
        
        }
    }
}