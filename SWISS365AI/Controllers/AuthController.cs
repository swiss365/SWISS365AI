using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swiss365AI.Domain.Entities;
using Swiss365AI.Infrastructure;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
        if (dbUser == null || dbUser.PasswordHash != user.PasswordHash)
        {
            return Unauthorized();
        }

        return Ok(new { Token = "TestJWTToken123" });
    }
}
