using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBackend.Models;

namespace NewBackend
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "db");
            builder.HasKey(a => a.IdUser);
            builder.Property(a => a.IdUser)
                    .HasColumnType("int")
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            builder.Property(u => u.Email)
                    .HasColumnType("varchar")
                    .HasMaxLength(20)
                    .IsRequired();
            builder.Property(u => u.Password)
                    .HasColumnType("varchar")
                    .HasMaxLength(20)
                    .IsRequired();
            builder.Property(u => u.IsAdmin)
                    .HasColumnType("int")
                    .IsRequired();
            builder.Property(u => u.Name)
                    .HasColumnType("varchar")
                    .HasMaxLength(20)
                    .IsRequired();
            builder.Property(u => u.Surname)
                    .HasColumnType("varchar")
                    .HasMaxLength(20)
                    .IsRequired();
            builder.Property(u => u.Address)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
            builder.Property(u => u.Phone)
                    .HasColumnType("varchar")
                    .HasMaxLength(20);
            builder.Property(u => u.ImgPath)
                    .HasColumnType("varchar")
                    .HasMaxLength(1000);
                
                // builder.HasMany<FavouritesUserBooks>(user => user.FavouriteBooks)
                //         .WithOne(fav => fav.Book)
                        
        }
    }
}