namespace _2026_LendARoom_backend.Models;

public class LoanRequest
{
    public int Id{ get; set; }
    public int UserId{ get; set; }
    public int RoomId{ get; set; }
    public DateTime RequestDate{ get; set; } = DateTime.Now;
    public DateTime BorrowDate{ get; set; }
    public DateTime ReturnDate{ get; set; }
    public string Description{ get; set; } = string.Empty;
    public string Status{ get; set; } = "Pending"; //"Pending", "Approved", "Rejected", and "Completed"

    public User? User{ get; set; }
    public Room? Room{ get; set; } 
}