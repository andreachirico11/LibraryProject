using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBackend.Models;

namespace NewBackend
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        { 
             builder.ToTable("Books", "db");
             builder.HasKey(b => b.IdBook);
             builder.Property(b => b.IdBook)
                    .HasColumnType("int")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            builder.Property(b => b.Title)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired();
            builder.Property(b => b.Editor)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired();
            builder.Property(b => b.PublishingYear)
                    .HasColumnType("int");
            builder.Property(b => b.Description)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .HasMaxLength(500);
            builder.Property(b => b.Isbn)
                    .HasColumnType("varchar")
                    .HasMaxLength(50)
                    .IsRequired();

        }
    }
}