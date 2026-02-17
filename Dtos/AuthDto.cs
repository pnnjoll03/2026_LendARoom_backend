namespace _2026_LendARoom_backend.Dtos;

public class RegisterDto
{
    public string Username{ get; set; } = string.Empty;
    public string Password{ get; set; } = string.Empty;
    public string NRP{ get; set; } = string.Empty;
    public string Class{ get; set;} = string.Empty;
}

public class LoginDto
{
    public string Username{ get; set; } = string.Empty;
    public string Password{ get; set; } = string.Empty; 
}