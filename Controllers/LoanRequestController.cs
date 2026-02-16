using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_LendARoom_backend.Models;
using _2026_LendARoom_backend.Data;
using _2026_LendARoom_backend.Dtos;

namespace _2026_LendARoom_backend.Controllers;

[Route("api/[controller]")]
[ApiController]

public class LoanRequestController : ControllerBase
{
    private readonly AppDbContext _context;
    public LoanRequestController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("booking")]
    public async Task<IActionResult> CreateLoanRequest(CreateLoanRequestDto request)
    {
        if(request.ReturnDate <= request.BorrowDate)
        {
            return BadRequest("Waktu selesai peminjaman harus lebih dari waktu mulai!");
        }
        var user = await _context.Users.FirstOrDefaultAsync(u => u.NRP == request.NRP);

        if( user == null)
        {
            return BadRequest("Mahasiswa tidak ditemukan!");
        }

        var newLoanRequest = new LoanRequest
        {
            UserId = user.Id,
            RoomId = request.RoomId,
            RequestDate = DateTime.Now,
            BorrowDate =  request.BorrowDate,
            ReturnDate = request.ReturnDate,
            Description =   request.Description,
            Status = "Pending"
        };

        _context.LoanRequests.Add(newLoanRequest);
        await _context.SaveChangesAsync();

        return Ok("Booking berhasil diajukan, tunggu persetujuan admin");
    }

    [HttpPut("{id}/completed")]
    public async Task<IActionResult> CompleteBooking(int id)
    {
        var loan = await _context.LoanRequests.Include(l => l.User).Include(l => l.Room).FirstOrDefaultAsync(l => l.Id == id);
        if( loan == null ) return NotFound();
        if( loan.Status != "Approved")
        {
            return BadRequest("Hanya peminjaman yang disetujui yang dapat diselesaikan");
        }

        var history = new LoanHistory
        {
            UserId = loan.UserId,
            Name = loan.User?.Username ?? "Unknown",
            RoomName = loan.Room?.Name ?? "Unknown",
            BorrowDate = loan.BorrowDate,
            ReturnDate = DateTime.Now,
            Description = loan.Description,
            Status = "Completed"
        };

        _context.LoanHistories.Add(history);

        if( loan.Room != null)
        {
            loan.Room.Status = "Tersedia";
        }

        loan.Status = "Completed";

        await _context.SaveChangesAsync();
        return Ok("Peminjaman Selesai!");
    }

    [HttpPut("{id}/reject")]
    public async Task<IActionResult> RejectBooking(int id)
    {
        var loan = await _context.LoanRequests.FindAsync(id);
        if( loan == null ) return NotFound();

        loan.Status = "Rejected";

        await _context.SaveChangesAsync();
        return Ok("Peminjaman telah ditolak!");
    }

    [HttpPut("{id}/approve")]
    public async Task<IActionResult> ApproveBooking(int id)
    {
        var loan = await _context.LoanRequests.Include(l => l.Room).FirstOrDefaultAsync(l => l.Id == id);
        if( loan == null ) return NotFound();

        loan.Status = "Approved";

        if( loan.Room != null)
        {
            loan.Room.Status = "Sedang dipakai";
        }

        await _context.SaveChangesAsync();
        return Ok("Booking disetujui");
    }

    [HttpPut("{id}/editloanrequest")]
    public async Task<IActionResult> EditLoanRequest(int id, EditLoanRequestDto request)
    {
        var loan = await _context.LoanRequests.FindAsync(id);

        if( loan == null)
        {
            return NotFound("Data peminjaman tidak dapat ditemukan");
        }

        if( loan.Status != "Pending")
        {
            return BadRequest("Pengeditan hanya bisa dilakukan ketika status 'Pending'!");
        }

        if(request.ReturnDate <= request.BorrowDate)
        {
            return BadRequest("Waktu selesai peminjaman harus lebih dari waktu mulai!");
        }

        loan.BorrowDate = request.BorrowDate;
        loan.ReturnDate = request.ReturnDate;
        loan.Description = request.Description;

        await _context.SaveChangesAsync();
        return Ok("Data peminjaman berhasil di edit!");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanRequest>>> GetLoanRequest()
    {
        return await _context.LoanRequests.Include(l => l.User).Include(l => l.Room).ToListAsync();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLoanRequest(int id)
    {
        var loan = await _context.LoanRequests.FindAsync(id);
        if( loan == null)
        {
            return NotFound();
        }

        if( loan.Status != "Pending")
        {
            return BadRequest("Penghapusan data peminjaman hanya bisa dilakukan ketika status 'Pending'!");
        }

        _context.LoanRequests.Remove(loan);
        await _context.SaveChangesAsync();

        return Ok("Data peminjaman berhasil dihapus!");
    }

    [HttpGet("user/{username}")]
    public async Task<ActionResult<IEnumerable<LoanRequest>>> GetUserLoanRequests(string username)
    {
        return await _context.LoanRequests
            .Include(l => l.Room) // Penting: Supaya data ruangan ikut terbawa
            .Where(l => l.User != null && l.User.Username == username)
            .ToListAsync();
    }
}