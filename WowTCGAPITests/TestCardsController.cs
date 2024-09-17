using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System.Net.Sockets;
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
        private readonly Mock<DbSet<Card>> _mockSet;

        public CardsControllerTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _controller = new CardsController(_mockContext.Object);
            _mockSet = new Mock<DbSet<Card>>();

            var cards = new List<Card> {
                new Card { Id = 1, Name = "Card1", Description = "Test", Rarity = "High" },
                new Card { Id = 2, Name = "Card2", Description = "Test2", Rarity = "Common" }
            }.AsQueryable();

            _mockSet.As<IQueryable<Card>>().Setup(m => m.Provider).Returns(cards.Provider);
            _mockSet.As<IQueryable<Card>>().Setup(m => m.Expression).Returns(cards.Expression);
            _mockSet.As<IQueryable<Card>>().Setup(m => m.ElementType).Returns(cards.ElementType);
            _mockSet.As<IQueryable<Card>>().Setup(m => m.GetEnumerator()).Returns(cards.GetEnumerator());

            _mockContext.Setup(c => c.Cards).ReturnsDbSet(_mockSet.Object);
        }

        [Fact]
        public async Task GetCards_ReturnsOkResult_WithListOfCards()
        {
            var result = await _controller.GetCards();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnCards = Assert.IsType<List<Card>>(okResult.Value);
            Assert.Equal(2, returnCards.Count);
            Assert.Equal("Card1", returnCards.First().Name);
        }

        [Fact]
        public async void AddCard_AddsCardToDatabase()
        {
            var newCard = new Card { Id = 3, Name = "Card3", Description="card3", Rarity="low", Price=51 };

            // Act
            var result = await _controller.CreateCard(newCard);

            // Assert
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnCard = Assert.IsType<Card>(createdAtActionResult.Value);
            Assert.Equal(newCard.Name, returnCard.Name);
        }
    }
}
