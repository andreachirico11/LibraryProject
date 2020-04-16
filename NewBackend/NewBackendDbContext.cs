using Microsoft.EntityFrameworkCore;
using NewBackend.Models;

namespace NewBackend
{
    public partial class NewBackendDbContext : DbContext
    {
        public NewBackendDbContext(DbContextOptions options) : base(options)
        {
        }

        public NewBackendDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\sqserver;Data Source=127.0.0.1;Initial Catalog=GoodLibraryDb;User ID=SA; Password=yourStrong(!)Password;");
        }
        // #######################################################################################################


        public DbSet<Author> Authors { get; set; }
        public DbSet<Book > Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new LoanConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<FavouritesUserBooks>().ToTable("Favourites", "db")
                        .HasKey(k => new {k.IdUser, k.IdBook});
        }
    }
}