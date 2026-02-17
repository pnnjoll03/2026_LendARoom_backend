using _2026_LendARoom_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace _2026_LendARoom_backend.Services;

public class BookingBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public BookingBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try 
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var expiredBookings = await context.LoanRequests
                        .Where(b => b.Status == "Approved" && b.ReturnDate <= DateTime.Now)
                        .ToListAsync();

                    if (expiredBookings.Any())
                    {
                        foreach (var booking in expiredBookings)
                        {
                            booking.Status = "Completed";
                            var room = await context.Rooms.FindAsync(booking.RoomId);
                            if (room != null) room.Status = "Tersedia";
                        }
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error BackgroundService]: {ex.Message}");
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}