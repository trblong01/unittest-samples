using Moq;
using Clothes.Application.DeleteClothe;
using Clothes.Domain.Entities;
using Clothes.Domain.Repositories;
using Clothes.Application.UnitTests.DeleteClotheTest;
using System.Net;
using System.Text;
using Clothes.Application.Results;
using System.Text.Json;

namespace Clothes.UnitTest.DeleteClotheTest
{
    [Collection("HttpClient Collection")]
    public class DeleteClotheCommandHandler2UnitTest
    {
        private readonly DeleteClotheCommandValidator _validator;
        private readonly Mock<IRepository<ClotheEntity>> _repositoryMock;
        private readonly DeleteClotheCommandHandler2 _handler;

        public DeleteClotheCommandHandler2UnitTest(HttpClientFixture fixture)
        {
            _fixture = fixture;
            _httpClient = fixture.HttpClient;
            _validator = new DeleteClotheCommandValidator();
            _repositoryMock = new Mock<IRepository<ClotheEntity>>();
            _handler = new DeleteClotheCommandHandler2(_repositoryMock.Object, _httpClient, _validator);
            
        }
        private readonly HttpClientFixture _fixture;
        private readonly HttpClient _httpClient;

       
        [Fact]
        [Trait("Category", "Clothe")]
        public async Task Handle_ValidRequest_ShouldReturnSuccessResult()
        {
            // Arrange
            var mockResponse = new Result(true, "Ok", "CustomData" );

            _fixture.AddResponse(DeleteClotheCommandHandler2.ApiUrl, new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(mockResponse), Encoding.UTF8, "application/json")
            });


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
