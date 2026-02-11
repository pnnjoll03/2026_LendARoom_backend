using Microsoft.AspNetCore.Mvc;

namespace _2026_LendARoom_backend.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TesController : ControllerBase
{
    [HttpGet]
    public string SapaSaya()
    {
        return "Halo! Ini adalah controller yang saya buat";
    }
}