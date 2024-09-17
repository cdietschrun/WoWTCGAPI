using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

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

    /// <summary>
    /// Creates a new card.
    /// </summary>
    /// <param name="card">The card information to create.</param>
    /// <returns>The created card.</returns>
    [HttpPost]
    [SwaggerResponse(statusCode: StatusCodes.Status201Created, type: null, description: "ID of the created card.")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCard([FromBody] Card card)
    {
        _context.Cards.Add(card);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCards), new { id = card.Id }, card);
    }

    // Additional actions for card management
}