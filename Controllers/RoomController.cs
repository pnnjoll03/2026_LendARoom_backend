using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_LendARoom_backend.Data;
using _2026_LendARoom_backend.Models;
using _2026_LendARoom_backend.Dtos;

namespace _2026_LendARoom_backend.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RoomController : ControllerBase
{
    private readonly AppDbContext _context;
    public RoomController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("addRoom")]
    public async Task<IActionResult> AddRoom(AddRoomDto request)
    {
        if(await _context.Rooms.AnyAsync(r => r.Name == request.Name))
        {
            return BadRequest("Nama ruangan sudah dipakai!");
        }

        var newRoom = new Room
        {
            Name = request.Name,
            Status = "Tersedia",
            Capacity = request.Capacity,
            Location = request.Location
        };

        _context.Rooms.Add(newRoom);
        await _context.SaveChangesAsync();

        return Ok("Ruangan berhasil di tambahkan!");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetRoom()
    {
        return await _context.Rooms.ToListAsync();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if(room == null) return NotFound();

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        return Ok("Ruangan berhasil dihapus!");  
    }
}