using Microsoft.EntityFrameworkCore;

public class CardService
{
    private readonly ApplicationDbContext _context;

    public CardService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Card>> GetCardsAsync()
    {
        return await _context.Cards.ToListAsync();
    }

    // Additional methods for card management
}