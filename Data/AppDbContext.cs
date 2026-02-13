using Microsoft.EntityFrameworkCore;
using _2026_LendARoom_backend.Models;

namespace _2026_LendARoom_backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users{ get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<LoanRequest> LoanRequests{ get; set;}
    public DbSet<LoanHistory> LoanHistories{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>().HasData(
            new Room { Id = 1, Name = "Auditorium PENS", Status="Tersedia", Capacity=600, Location="Gedung SAW Lt.6"},
            new Room { Id = 2, Name = "Mini Teater", Status="Tersedia", Capacity=150, Location="Gedung SAW Lt.6"},
            new Room { Id = 3, Name = "Teater D3", Status="Tersedia", Capacity=150, Location="Gedung D3 PENS"},
            new Room { Id = 4, Name = "Student Center Lt.1", Status="Tersedia", Capacity=200, Location="Disebelah Masjid An-Nahl PENS"},
            new Room { Id = 5, Name = "Student Center Lt.2", Status="Tersedia", Capacity=200, Location="Disebelah Masjid An-Nahl PENS"},
            new Room { Id = 6, Name = "Student Center Lt.3", Status="Tersedia", Capacity=200, Location="Disebelah Masjid An-Nahl PENS"}
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "Admin1", Password = "Admin123" , Role = "Admin" }
        );
    }
}