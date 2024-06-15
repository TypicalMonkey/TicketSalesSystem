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
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();

            // Konfiguracja dla Train
            modelBuilder.Entity<Train>().ToTable("Trains");
            modelBuilder.Entity<Train>().HasKey(t => t.Id);
            modelBuilder.Entity<Train>().Property(t => t.BrandId).IsRequired();
            modelBuilder.Entity<Train>().Property(t => t.ModelId).IsRequired();
            modelBuilder.Entity<Train>().Property(t => t.Seats).IsRequired();
            modelBuilder.Entity<Train>().Property(t => t.Year).IsRequired();
            modelBuilder.Entity<Train>().Property(t => t.HasWifi).IsRequired();
            modelBuilder.Entity<Train>().Property(t => t.AdditionalInfo);

            // Konfiguracja dla Route
            modelBuilder.Entity<Route>().ToTable("Routes");
            modelBuilder.Entity<Route>().HasKey(r => r.Id);
            modelBuilder.Entity<Route>().Property(r => r.Name).IsRequired();
            modelBuilder.Entity<Route>().HasMany(r => r.Stations).WithMany().UsingEntity(j => j.ToTable("RouteStations"));

            // Konfiguracja dla Station
            modelBuilder.Entity<Station>().ToTable("Stations");
            modelBuilder.Entity<Station>().HasKey(s => s.Id);
            modelBuilder.Entity<Station>().Property(s => s.Name).IsRequired();

            // Konfiguracja dla Ticket
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            modelBuilder.Entity<Ticket>().HasKey(t => t.Id);
            modelBuilder.Entity<Ticket>().Property(t => t.RouteId).IsRequired();
            modelBuilder.Entity<Ticket>().Property(t => t.PurchaseDate).IsRequired();
            modelBuilder.Entity<Ticket>().Property(t => t.Price).IsRequired();

            // Konfiguracja dla Model
            modelBuilder.Entity<Model>().ToTable("Models");
            modelBuilder.Entity<Model>().HasKey(m => m.Id);
            modelBuilder.Entity<Model>().Property(m => m.Name).IsRequired();

            // Konfiguracja dla Brand
            modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<Brand>().HasKey(b => b.Id);
            modelBuilder.Entity<Brand>().Property(b => b.Name).IsRequired();
        }
    }
}
