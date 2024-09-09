using Moq;
using Germac.Domain.Repositories;
using Germac.Domain.Entities;
using Germac.Application.Commands.CreateOrderCommand;
using Serilog;
using Germac.Application.Commands.CreatePartCommand;

namespace Germac.Tests.UnitTest
{
    public class CreateOrderCommandUnitTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<ILogger> _loggerMock;
        private readonly CreateOrderCommand _createOrderCommand;

        public CreateOrderCommandUnitTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _loggerMock = new Mock<ILogger>();

            // Instantiate the command handler with mocked dependencies
            _createOrderCommand = new CreateOrderCommand(_orderRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Create_Order_Successfully()
        {
            // Arrange
            var request = new CreateOrderRequest
            {
                OrderNumber = 1,
                TotalPrice = 150.00m
            };

            var order = new Order(request.OrderNumber, request.TotalPrice);

            // Mock the repository's Add method to return a successful creation
            _orderRepositoryMock
                .Setup(repo => repo.Add(It.IsAny<string>(), It.IsAny<Order>()))
                .ReturnsAsync(1);

            // Act
            var result = await _createOrderCommand.Handle(request, CancellationToken.None);

            // Assert
            _orderRepositoryMock.Verify(repo => repo.Add(It.IsAny<string>(), It.IsAny<Order>()), Times.Once);
            _loggerMock.Verify(logger => logger.Information(It.IsAny<string>()), Times.Exactly(4));

            Assert.NotNull(result);
            Assert.IsType<CreateOrderResponse>(result);
        }

        [Fact]
        public async Task Handle_Should_Log_Information()
        {
            // Arrange
            var request = new CreateOrderRequest
            {
                OrderNumber = 1,
                TotalPrice = 200.00m
            };

            var order = new Order(request.OrderNumber, request.TotalPrice);

            _orderRepositoryMock
                .Setup(repo => repo.Add(It.IsAny<string>(), It.IsAny<Order>()))
                .ReturnsAsync(1);

            // Act
            await _createOrderCommand.Handle(request, CancellationToken.None);

            // Assert that the logger was called with specific messages
            _loggerMock.Verify(logger => logger.Information($"Starting Handler {nameof(CreatePartCommand)}"), Times.Once);
            _loggerMock.Verify(logger => logger.Information("Order Created"), Times.Once);
            _loggerMock.Verify(logger => logger.Information($"Finishing Handler {nameof(CreatePartCommand)}"), Times.Once);
        }
    }
}
