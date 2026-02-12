using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_LendARoom_backend.Data;
using _2026_LendARoom_backend.Dtos;
using _2026_LendARoom_backend.Models;

namespace _2026_LendARoom_backend.Controllers;

[Route("api/[controller]")]
[ApiController]

public class LoanHistoryController : ControllerBase
{
    private readonly AppDbContext _context;
    public LoanHistoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPut("{id}/editloanhistory")]
    public async Task<IActionResult> EditLoanHistory(int id, EditLoanHistoryDto request)
    {
        var history = await _context.LoanHistories.FindAsync(id);
        if( history == null)
        {
            return NotFound("Data riwayat peminjaman tidak ditemukan!");
        }

        history.BorrowDate = request.BorrowDate;
        history.ReturnDate = request.ReturnDate;
        history.Description = request.Description;
        history.Status = request.Status;

        await _context.SaveChangesAsync();
        return Ok("Data riwayat peminjaman berhasil di edit!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLoanHistory(int id)
    {
        var history = await _context.LoanHistories.FindAsync(id);
        if( history == null)
        {
            return NotFound();
        }

        _context.LoanHistories.Remove(history);
        await _context.SaveChangesAsync();

        return Ok("Riwayat peminjaman berhasil dihapus!");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanHistory>>> GetLoanHistory()
    {
        return await _context.LoanHistories.ToListAsync();
    }
}