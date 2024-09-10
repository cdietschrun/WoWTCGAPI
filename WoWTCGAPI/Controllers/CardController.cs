// Controllers/CardsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/card")]
public class CardsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CardsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCards()
    {
        var cards = await _context.Cards.ToListAsync();
        return Ok(cards);
    }

    // Additional actions for card management
}