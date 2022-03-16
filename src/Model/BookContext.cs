using Microsoft.EntityFrameworkCore;

namespace BookAPI.Model
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Book>()
                .Property(b => b.Description)
                .HasColumnType("varchar(200)");

            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired()
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Book>()
                .Property(b => b.Author)
                .IsRequired()
                .HasColumnType("varchar(100)");
        }
    }
}
