//using Germac.Application.Command.CreateOrderCommand;
//using Germac.Domain.Repositories;
//using Moq;

//namespace Germac.Tests.UnitTest
//{
//    public class CreateOrderCommandUnitTests
//    {
//        [Fact]
//        public async Task Handle_ShouldCreateProductAndReturnId()
//        {
//            // Arrange
//            var mockContext = new Mock<IOrderRepository>();
//            var handler = new CreateOrderCommand(mockContext.Object);

//            // Act
//            var command = new CreateOrderCommand("Test Product", 100);
//            var result = await handler.Handle(command, CancellationToken.None);

//            // Assert
//            Assert.True(result > 0);
//            mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
//        }
//    }
//}
