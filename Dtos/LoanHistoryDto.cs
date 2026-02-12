namespace _2026_LendARoom_backend.Dtos;

public class EditLoanHistoryDto
{
    public DateTime BorrowDate{ get; set; }
    public DateTime ReturnDate{ get; set; }
    public string Description{ get; set; } = string.Empty;
    public string Status{ get; set; } = string.Empty;
}