using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace WoWTCGAPITests
{
    /// <summary>
    /// Contains unit tests for the CardsController.
    /// </summary>
    public class CardsControllerTests
    {
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly CardsController _controller;

        public CardsControllerTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _controller = new CardsController(_mockContext.Object);
        }

        [Fact]
        public async Task GetAllCards_ReturnsOkResult_WithListOfCards()
        {
            // Arrange
            var cards = new List<Card> { new Card { Id = 1, Name = "Card1", Description="Test", Rarity="High" }, new Card { Id = 2, Name = "Card2", Description="Test2", Rarity="Common" } };
            _mockContext.Setup(c => c.Cards).ReturnsDbSet(cards);

            // Act
            var result = await _controller.GetCards();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnCards = Assert.IsType<List<Card>>(okResult.Value);
            Assert.Equal(2, returnCards.Count);
        }
    }
}
