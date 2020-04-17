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
                    .HasColumnType("varchar(20)")
                    //     .HasMaxLength(20)
                    .IsRequired();
            builder.Property(u => u.Password)
                    .HasColumnType("varchar(20)")
                    //     .HasMaxLength(20)
                    .IsRequired();
            builder.Property(u => u.IsAdmin)
                    .HasColumnType("int")
                    .IsRequired();
            builder.Property(u => u.Name)
                    .HasColumnType("varchar(20)")
                    //     .HasMaxLength(20)
                    .IsRequired();
            builder.Property(u => u.Surname)
                    .HasColumnType("varchar(20)")
                    //     .HasMaxLength(20)
                    .IsRequired();
            builder.Property(u => u.Address)
                    .HasColumnType("varchar(50)")
                    //     .HasMaxLength(50)
                    ;
            builder.Property(u => u.Phone)
                    .HasColumnType("varchar(20)")
                    //     .HasMaxLength(20)
                    ;
            builder.Property(u => u.ImgPath)
                    .HasColumnType("varchar(1000)")
                    //     .HasMaxLength(1000)
                    ;


                // builder.HasData(new User("lorena@email.it", "lorena123", 0, "Lorena", "Schirru", 1, "Via Roma, 88", "1234567890", "https://source.unsplash.com/EbQRjuEdFcg"));
                // builder.HasData(new User("pino@email.it","pino123", 1, "Pino", "Rossi", 2, "Piazza Italia 8", "333123123", "https://source.unsplash.com/4nulm-JUYFo"));
                // builder.HasData(new User("bianchi@email.it", "bianchi123", 0, "Paolo", "Bianchi", 3, "VIa della liberta 4", null, "https://source.unsplash.com/NAdFJtFFlHE"));
                // builder.HasData(new User("benvenuto@email.it", "benvenuto123", 0, "Simone", "Benvenuto", 4, "Via muccarloa", "0105345345", "https://source.unsplash.com/2RhlxwRz4yc"));

        }
    }
}