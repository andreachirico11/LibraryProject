using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBackend.Models;

namespace NewBackend
{
    public class UserFavouritesConfiguration : IEntityTypeConfiguration<FavouritesUserBooks>
    {
        public void Configure(EntityTypeBuilder<FavouritesUserBooks> builder)
        {

            
            builder.ToTable("Favourites", "db").HasKey(k => new {k.IdUser, k.IdBook});

            builder.HasOne(fav => fav.Book)
                    .WithMany(b => b.FavouritesUserBooks)
                    .HasForeignKey(fav => fav.IdBook);
            builder.HasOne(fav => fav.User)
                    .WithMany(u => u.FavouritesUserBooks)
                    .HasForeignKey(fav => fav.IdUser);
        }
    }
}