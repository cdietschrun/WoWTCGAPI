using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public virtual DbSet<Card> Cards { get; set; }
    //public DbSet<Collection> Collections { get; set; }
    //public DbSet<Deck> Decks { get; set; }
    //public DbSet<Price> Prices { get; set; }

    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}