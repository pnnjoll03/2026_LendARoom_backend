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
}