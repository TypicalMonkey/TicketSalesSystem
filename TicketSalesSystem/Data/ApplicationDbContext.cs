using Microsoft.EntityFrameworkCore;
using TicketSalesSystem.Models;

namespace TicketSalesSystem.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TicketSellerSystem.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja dla User
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).ValueGeneratedOnAdd(); // Auto increment
                entity.Property(u => u.Username).IsRequired();
                entity.Property(u => u.Password).IsRequired();
                entity.Property(u => u.Email).IsRequired();
            });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin",
                    Email = "pancerny677@interia.pl",
                    UserRole = UserRole.Admin
                }
            );

            // Konfiguracja dla Train
            modelBuilder.Entity<Train>(entity =>
            {
                entity.ToTable("Trains");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd(); // Auto increment
                entity.Property(t => t.BrandId).IsRequired();
                entity.Property(t => t.ModelId).IsRequired();
                entity.Property(t => t.Seats).IsRequired();
                entity.Property(t => t.Year).IsRequired();
                entity.Property(t => t.HasWifi).IsRequired();
                entity.Property(t => t.AdditionalInfo);
            });

            // Konfiguracja dla Route
            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("Routes");
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Id).ValueGeneratedOnAdd(); // Auto increment
                entity.Property(r => r.Name).IsRequired();
                entity.HasMany(r => r.Stations).WithMany().UsingEntity(j => j.ToTable("RouteStations"));
            });

            // Konfiguracja dla Station
            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("Stations");
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id).ValueGeneratedOnAdd(); // Auto increment
                entity.Property(s => s.Name).IsRequired();
            });

            // Konfiguracja dla Ticket
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Tickets");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd(); // Auto increment
                entity.Property(t => t.RouteId).IsRequired();
                entity.Property(t => t.PurchaseDate).IsRequired();
                entity.Property(t => t.Price).IsRequired();
            });

            // Konfiguracja dla Model
            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("Models");
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Id).ValueGeneratedOnAdd(); // Auto increment
                entity.Property(m => m.Name).IsRequired();
            });

            // Konfiguracja dla Brand
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Id).ValueGeneratedOnAdd(); // Auto increment
                entity.Property(b => b.Name).IsRequired();
            });
        }
    }
}
