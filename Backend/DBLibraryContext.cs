using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Models
{
    public partial class DBLibraryContext : DbContext
    {
        public DBLibraryContext()
        {
        }

        public DBLibraryContext(DbContextOptions<DBLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Loans> Loans { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserFavourites> UserFavourites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("DataSource=C:\\Users\\andrea.chirico.P-ACHIRICO\\Desktop\\LibraryProject\\Database\\DBLibrary.db");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.IdAuthor);

                entity.HasIndex(e => e.IdAuthor)
                    .IsUnique();

                entity.Property(e => e.IdAuthor)
                    .HasColumnName("id_author")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.IdBook);

                entity.HasIndex(e => e.IdBook)
                    .IsUnique();

                entity.Property(e => e.IdBook)
                    .HasColumnName("id_book")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Editor)
                    .IsRequired()
                    .HasColumnName("editor");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.Isbn).HasColumnName("isbn");

                entity.Property(e => e.PublishingYear).HasColumnName("publishing_year");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.HasKey(e => e.IdGenre);

                entity.HasIndex(e => e.IdGenre)
                    .IsUnique();

                entity.Property(e => e.IdGenre)
                    .HasColumnName("id_genre")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Loans>(entity =>
            {
                entity.HasKey(e => e.IdLoan);

                entity.HasIndex(e => e.IdLoan)
                    .IsUnique();

                entity.Property(e => e.IdLoan)
                    .HasColumnName("id_loan")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateReturn)
                    .HasColumnName("date_return")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.DateStart)
                    .IsRequired()
                    .HasColumnName("date_start")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.IdBook).HasColumnName("id_book");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserFavourites>(entity =>
            {
                entity.HasKey(e => e.IdFav);

                entity.HasIndex(e => e.IdFav)
                    .IsUnique();

                entity.Property(e => e.IdFav)
                    .HasColumnName("idFav")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdBook).HasColumnName("idBook");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Favourites)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.UserFavourites)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Users>(entity =>
            {

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Password).HasColumnName("password");
                
                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname");
                
                entity.HasKey(e => e.IdUser);
                
                entity.HasIndex(e => e.IdUser)
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .ValueGeneratedNever();
                
                entity.Property(e => e.Address).HasColumnName("address");
                
                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.ImgPath).HasColumnName("imgPath");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
