namespace _2026_LendARoom_backend.Dtos;
public class AddRoomDto
{
    public string Name{ get; set; } = string.Empty;
    public int Capacity{ get; set; }
    public string Location{ get; set; } = string.Empty;
}