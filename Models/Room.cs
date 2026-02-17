using Microsoft.AspNetCore.Identity;

namespace _2026_LendARoom_backend.Models;

public class Room
{
    public int Id{ get; set;}
    public string Name{ get; set; } = string.Empty;
    public string Status{ get; set; } = "Tersedia"; // "Tersedia", "Sedang dipakai", dan "Sedang dalam perbaikan"
    public int Capacity{ get; set; }
    public string Location{ get; set; } = string.Empty; 
}