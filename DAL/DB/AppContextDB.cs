using Microsoft.EntityFrameworkCore;
using Task_25_7_1.DAL.Configuration;
using Task_25_7_1.DAL.Entities;

namespace Task_25_7_1.DAL.DB
{
    public class AppContextDB : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<UserBook> UsersBooks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.MsSqlConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(p => p.Author)
                .WithMany(t => t.Books)
                .HasForeignKey(p => p.AuthorId);

            modelBuilder.Entity<UserBook>()
                .HasOne(p => p.User)
                .WithMany(t => t.UserBooks)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserBook>()
                .HasOne(p => p.Book)
                .WithMany(t => t.UserBooks)
                .HasForeignKey(p => p.BookId);
        }
    }
}
