using Microsoft.AspNetCore.Identity;

namespace _2026_LendARoom_backend.Models;

public class User
{
    public int Id{ get; set;}
    public string Username{ get; set; } = string.Empty;
    public string Password{ get; set; } = string.Empty;
    public string NRP{ get; set; } = string.Empty;
    public string Class{ get; set; } = string.Empty;
    public string Role{ get; set; } = "Mahasiswa"; // "Mahasiswa" dan "Admin"
}