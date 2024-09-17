using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/card")]
[Produces("application/json")]
public class CardsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CardsController(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets all cards
    /// </summary>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Returns cards</response>
    [HttpGet]
    public async Task<IActionResult> GetCards()
    {
        var cards = await _context.Cards.ToListAsync();
        return Ok(cards);
    }

    // Additional actions for card management
}