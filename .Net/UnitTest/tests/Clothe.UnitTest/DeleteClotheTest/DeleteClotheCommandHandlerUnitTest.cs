using Moq;
using Clothes.Application.DeleteClothe;
using Clothes.Domain.Entities;
using Clothes.Domain.Repositories;

namespace Clothes.UnitTest.DeleteClotheTest
{
    public class DeleteClotheCommandHandlerUnitTest
    {
        private readonly DeleteClotheCommandValidator _validator;
        private readonly Mock<IRepository<ClotheEntity>> _repositoryMock;
        private readonly DeleteClotheCommandHandler _handler;

        public DeleteClotheCommandHandlerUnitTest()
        {
            _validator = new DeleteClotheCommandValidator();
            _repositoryMock = new Mock<IRepository<ClotheEntity>>();
            _handler = new DeleteClotheCommandHandler(_repositoryMock.Object, _validator);
        }

        [Fact]
        [Trait("Category", "Clothe")]
        public async Task Handle_ValidRequest_ShouldReturnSuccessResult()
        {
            // Arrange
            var request = new DeleteClotheCommand(Guid.NewGuid());
            ClotheEntity? clothe = new ClotheEntity("Test","Cotton",2024,"XXL","Blue");
            _repositoryMock.Setup(r => r.GetByIdAsync(request.Id, It.IsAny<CancellationToken>())).ReturnsAsync(clothe);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Clothe deleted successfully", result.Message);
        }

        [Fact]
        [Trait("Category", "Clothe")]

        public async Task Handle_ValidRequest_But_not_contain_ShouldReturnFailResult()
        {
            // Arrange
            var request = new DeleteClotheCommand(Guid.NewGuid());
            ClotheEntity clothe = null;
            _repositoryMock.Setup(r => r.GetByIdAsync(request.Id, It.IsAny<CancellationToken>())).ReturnsAsync(clothe);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
           
        }
    }
}
