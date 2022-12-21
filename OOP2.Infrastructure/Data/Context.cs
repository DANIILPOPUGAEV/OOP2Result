using Microsoft.EntityFrameworkCore;
using OOP2.Domain.Models;

namespace OOP2.Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Writer>().HasData(
                new Writer
                {
                    Id = Guid.NewGuid(),
                    Name = "Антон",
                    Patronymic = "Павлович",
                    SecondName = "Чехов"
                },
                new Writer
                {
                    Id = Guid.NewGuid(),
                    Name = "Фёдор",
                    Patronymic = "Михайлович",
                    SecondName = "Достоевский"
                }
            );
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = Guid.NewGuid(), Name = "Роман" });
            /*
            modelBuilder.Entity<Writer>()
                .HasMany(e => e.Books)
                .WithOne(e => e.Writer)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Writer>()
                 .HasMany(e => e.Genres)
                 .WithOne(e => e.Writer)
                 .OnDelete(DeleteBehavior.NoAction);
            */
            modelBuilder.Entity<Writer>()
                .HasMany(w => w.Books)
                .WithMany(b => b.Writers);
            
        }
    }
}