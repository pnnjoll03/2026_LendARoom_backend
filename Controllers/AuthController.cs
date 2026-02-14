using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_LendARoom_backend.Data;
using _2026_LendARoom_backend.Models;
using _2026_LendARoom_backend.Dtos;
using System.Windows.Markup;

namespace _2026_LendARoom_backend.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto request)
    {
        if(await _context.Users.AnyAsync(u => u.Username == request.Username))
        {
            return BadRequest("Username sudah terdaftar!");
        }

        var newUser = new User
        {
            Username = request.Username,
            Password = request.Password,
            Role = "Mahasiswa",
            NRP = request.NRP,
            Class = request.Class
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return Ok("Registrasi Berhasil!");  
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

        if(user == null || user.Password != request.Password)
        {
            return BadRequest("Username atau password anda salah!");
        }

        return Ok(new
        {
            Message = "Login berhasil!",
            Username = user.Username,
            Role     = user.Role
        });
    }
}
