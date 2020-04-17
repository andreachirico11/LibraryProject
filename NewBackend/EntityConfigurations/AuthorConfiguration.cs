using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBackend.Models;

namespace NewBackend
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors", "db");
            builder.HasKey(a => a.IdAuthor);
            builder.Property(a => a.IdAuthor)
                    .HasColumnType("int")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            builder.Property(a => a.Name)
                    .HasColumnType("varchar(20)");
            builder.Property(a => a.Surname)
                    .HasColumnType("varchar(20)");

            builder.HasMany(auth => auth.Books)
                    .WithOne(book => book.Author)
                    .HasForeignKey(book => book.IdAuthor);


                // builder.HasData( new Author(1, "Agatha", "Christie"));
                // builder.HasData( new Author(2, "Carlo", "Capra"));
                // builder.HasData( new Author(3, "Giovanni", "Sabatucci"));
                // builder.HasData( new Author(4, "Alessandro", "Bellini"));
                // builder.HasData( new Author(5, "Sarah", "Gailey"));
                // builder.HasData( new Author(6, "Steven", "Levy"));
        }
    }
}