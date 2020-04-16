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
                    .HasColumnType("varchar")
                    .HasMaxLength(20);
            builder.Property(a => a.Surname)
                    .HasColumnType("varchar")
                    .HasMaxLength(20);
        }
    }
}