using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    using System.Net;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using Moq.Protected;
    using System.Collections.Generic;

namespace Clothes.Application.UnitTests.DeleteClotheTest
{

    // Define the collection
    [CollectionDefinition("HttpClient Collection")]
    public class HttpClientCollection : ICollectionFixture<HttpClientFixture>
    {
        // This class has no code and is used for xUnit's collection definition.
    }

    public class HttpClientFixture
    {
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;

        public HttpClient HttpClient { get; }

        // Dictionary to store custom responses for specific request URLs
        private readonly Dictionary<string, HttpResponseMessage> _responses = new();

        public HttpClientFixture()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            // Set up the SendAsync method
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync((HttpRequestMessage request, CancellationToken cancellationToken) =>
                {
                    // Return a response if it's configured for the specific URL
                    if (_responses.TryGetValue(request.RequestUri.ToString(), out var response))
                    {
                        return response;
                    }

                    // Default response
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Content = new StringContent($"No response configured for {request.RequestUri}")
                    };
                });

            HttpClient = new HttpClient(_mockHttpMessageHandler.Object);
        }

        // Method to add or update a response for a specific URL
        public void AddResponse(string url, HttpResponseMessage response)
        {
            _responses[url] = response;
        }

        // Method to clear all responses
        public void ClearResponses()
        {
            _responses.Clear();
        }
    }

}
