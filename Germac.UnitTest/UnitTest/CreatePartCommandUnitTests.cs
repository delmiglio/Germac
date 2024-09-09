using Moq;
using Germac.Domain.Repositories;
using Germac.Domain.Entities;
using Germac.Application.Commands.CreatePartCommand;
using Serilog;

namespace Germac.Tests.UnitTest
{
    public class CreatePartCommandUnitTests
    {
        private readonly Mock<IPartRepository> _partRepositoryMock;
        private readonly Mock<ILogger> _loggerMock;
        private readonly CreatePartCommand _createPartCommand;

        public CreatePartCommandUnitTests()
        {
            _partRepositoryMock = new Mock<IPartRepository>();
            _loggerMock = new Mock<ILogger>();

            _createPartCommand = new CreatePartCommand(_partRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Create_Part_Successfully()
        {
            // Arrange
            var request = new CreatePartRequest
            {
                Quantity = 1,
                Name = "Iphone",
                PartId = 1,
                Price = 150.00m,
                PartNumber = "P123"
            };

            var order = new Part(request.PartId, request.PartNumber, request.Name, request.Quantity, request.Price);

            // Mock the repository's Add method to return a successful creation
            _partRepositoryMock
                .Setup(repo => repo.Add(It.IsAny<string>(), It.IsAny<Part>()))
                .ReturnsAsync(1);

            // Act
            var result = await _createPartCommand.Handle(request, CancellationToken.None);

            // Assert
            _partRepositoryMock.Verify(repo => repo.Add(It.IsAny<string>(), It.IsAny<Part>()), Times.Once);
            _loggerMock.Verify(logger => logger.Information(It.IsAny<string>()), Times.Exactly(4));

            Assert.NotNull(result);
            Assert.IsType<CreatePartResponse>(result);
        }

        [Fact]
        public async Task Handle_Should_Log_Information()
        {
            // Arrange
            var request = new CreatePartRequest
            {
                Quantity = 1,
                Name = "Iphone",
                PartId = 1,
                Price = 150.00m,
                PartNumber = "P123"
            };

            var order = new Part(request.PartId, request.PartNumber, request.Name, request.Quantity, request.Price);

            _partRepositoryMock
                .Setup(repo => repo.Add(It.IsAny<string>(), It.IsAny<Part>()))
                .ReturnsAsync(1);

            // Act
            await _createPartCommand.Handle(request, CancellationToken.None);

            // Assert that the logger was called with specific messages
            _loggerMock.Verify(logger => logger.Information($"Starting Handler {nameof(CreatePartCommand)}"), Times.Once);
            _loggerMock.Verify(logger => logger.Information("Part Created"), Times.Once);
            _loggerMock.Verify(logger => logger.Information($"Finishing Handler {nameof(CreatePartCommand)}"), Times.Once);
        }
    }
}
