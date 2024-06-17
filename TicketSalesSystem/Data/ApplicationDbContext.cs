using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
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
        public DbSet<OrderedStation> OrderedStations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            var dbPath = @"C:\Users\enham\Desktop\Ticket\TicketSalesSystem\TicketSellerSystem.db";
            optionsBuilder
                .UseSqlite($"Data Source={dbPath}")
                .EnableSensitiveDataLogging()
                .LogTo(message => Debug.WriteLine(message), LogLevel.Information);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration for User
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).ValueGeneratedOnAdd();
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

            // Configuration for Train
            modelBuilder.Entity<Train>(entity =>
            {
                entity.ToTable("Trains");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(t => t.Seats).IsRequired();
                entity.Property(t => t.Year).IsRequired();
                entity.Property(t => t.HasWifi).IsRequired();
                entity.Property(t => t.AdditionalInfo);
            });

            // Configuration for Route
            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DepartureTime).IsRequired();
                entity.Property(e => e.ArrivalTime).IsRequired();
                entity.HasOne(e => e.Train)
                      .WithMany()
                      .HasForeignKey(e => e.TrainId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuration for Station
            modelBuilder.Entity<Station>(entity =>
            {
                entity.ToTable("Stations");
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id).ValueGeneratedOnAdd();
                entity.Property(s => s.Name).IsRequired();
            });

            // Configuration for OrderedStation
            modelBuilder.Entity<OrderedStation>(entity =>
            {
                entity.HasKey(os => os.Id);
                entity.HasOne(os => os.Route)
                      .WithMany(r => r.OrderedStations)
                      .HasForeignKey(os => os.RouteId);
                entity.HasOne(os => os.Station)
                      .WithMany()
                      .HasForeignKey(os => os.StationId);
            });

            // Configuration for Ticket
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Tickets");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(t => t.RouteId).IsRequired();
                entity.Property(t => t.PurchaseDate).IsRequired();
                entity.Property(t => t.Price).IsRequired();
            });
        }

    }
}
