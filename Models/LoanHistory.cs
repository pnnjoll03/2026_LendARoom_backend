namespace _2026_LendARoom_backend.Models;

public class LoanHistory
{
    public int Id{ get; set; }
    public int UserId{ get; set; }
    public string Name{ get; set; } = string.Empty;
    public string RoomName{ get; set; } = string.Empty;
    public DateTime BorrowDate{ get; set; }
    public DateTime ReturnDate{ get; set; }
    public string Description{ get; set; } = string.Empty;
    public string Status{ get; set; } = "Completed"; //"Completed" dan "Rejected"
}
