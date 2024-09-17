using System.ComponentModel.DataAnnotations;

public class Card
{
    /// <summary>
    /// Gets or sets the unique identifier for the card.
    /// </summary>
    [Required]
    [Key]
    //[Range(1, int.MaxValue, ErrorMessage="Card ID must be >= 1")]
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the card.
    /// </summary>
    [Required]
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the card.
    /// </summary>
    [Required]
    public required string Description { get; set; }

    /// <summary>
    /// Gets or sets the rarity of the card.
    /// </summary>
    [Required]
    public required string Rarity { get; set; }

    /// <summary>
    /// Gets or sets the price of the card.
    /// </summary>
    public decimal Price { get; set; }
}
