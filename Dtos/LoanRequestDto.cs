namespace _2026_LendARoom_backend.Dtos;

public class CreateLoanRequestDto
{
    public string Name{ get; set; } = string.Empty;
    public string NRP{ get; set; } = string.Empty;
    public int RoomId{ get; set; }
    public DateTime BorrowDate{ get; set; }
    public string Description{ get; set; } = string.Empty;
}
public class EditLoanRequestDto
{
    public DateTime BorrowDate{ get; set; }
    public string Description{ get; set; } = string.Empty;
}