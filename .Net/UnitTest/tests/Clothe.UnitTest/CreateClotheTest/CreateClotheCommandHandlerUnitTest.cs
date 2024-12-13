using Moq;
using Clothes.Application.CreateClothe;
using Clothes.Domain.Entities;
using Clothes.Domain.Repositories;

namespace Clothes.UnitTest.CreateClotheTest;

public class CreateClotheCommandHandlerUnitTest
{
    private readonly CreateClotheCommandValidator _validator;
    private readonly Mock<IRepository<ClotheEntity>> _repositoryMock;
    private readonly CreateClotheCommandHandler _handler;

    public CreateClotheCommandHandlerUnitTest()
    {
        _validator = new CreateClotheCommandValidator();
        _repositoryMock = new Mock<IRepository<ClotheEntity>>();
        _handler = new CreateClotheCommandHandler(_validator, _repositoryMock.Object);
    }

    // Fact is used when the test will always have the same result
    [Fact]
    [Trait("Category", "Clothe")]
    public async Task Handle_ValidRequest_ShouldReturnSuccessResult()
    {
        // Arrange
        var request = new CreateClotheCommand("Test", "Cotton", 2024, "XXL", "Color");

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Clothe created successfully", result.Message);

    }

    // Theory is used when the test can have different results depending on the input data
    [Theory]
    [InlineData(null, "Cotton", 2022, "S", "White")]
    [InlineData("Test", null, 2022, "M", "Black")]
    [InlineData("Test", "Cotton", 2024, "L", "")]
    [InlineData("Test", "Jean", 2022, null, "Blue")]
    [InlineData("Test", "Jean", 2022, "", "Red")]
    [Trait("Category", "Clothe")]
    public async Task Handle_InvalidRequest_ShouldReturnFailureResult(string name, string model, int year, string size, string color)
    {
        // Arrange
        var request = new CreateClotheCommand(name, model, year, size, color);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.False(result.Success);
        Assert.Equal("Invalid data", result.Message);

    }
}
