using Microsoft.EntityFrameworkCore;
using DowJones.Models;

namespace DowJones.DAL
{
    public class DowJonesContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public DowJonesContext(DbContextOptions<DowJonesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Users
            builder.Entity<User>().HasKey(table => new {
                table.Id
            });
            builder.Entity<User>().Property(p => p.Name).HasColumnName("Nombre");
            builder.Entity<User>().Property(p => p.Surnames).HasColumnName("Apellidos");
            builder.Entity<User>().ToTable("Usuarios");

            //Stocks
            builder.Entity<Stock>().HasKey(table => new {
                table.Id
            });
            builder.Entity<Stock>().Property(p => p.Name).HasColumnName("Nombre");
            builder.Entity<Stock>().Property(p => p.Price).HasColumnName("Precio");
            builder.Entity<Stock>().ToTable("Stocks");
        }
    }
}
