namespace Marketplace.API.Controllers
{
    using Marketplace.API.Domain;
    using Marketplace.API.Infrastructure;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("API Working 🎉");
        }
    

    private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }
    }
}

