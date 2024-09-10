using Microsoft.EntityFrameworkCore;

using Xunit;

public class CardsControllerTests
{
    [Fact]
    public async Task GetCards_ReturnsOkResult_WithListOfCards()
    {
    //    // Arrange
    //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    //        .UseInMemoryDatabase(databaseName: "TestDatabase")
    //        .Options;

    //    using var context = new ApplicationDbContext(options);
    //    context.Cards.Add(new Card { Name = "Test Card" });
    //    context.SaveChanges();

    //    var controller = new CardsController(context);

    //    // Act
    //    var result = await controller.GetCards();

    //    // Assert
    //    var okResult = Assert.IsType<OkObjectResult>(result);
    //    var cards = Assert.IsType<List<Card>>(okResult.Value);
    //    Assert.Single(cards);
    }
}
