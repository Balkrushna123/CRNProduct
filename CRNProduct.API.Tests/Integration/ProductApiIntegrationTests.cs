using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CRNProduct.API.Tests.Integration
{
    public class ProductApiIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProductApiIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_Product_WithoutToken_ShouldReturnUnauthorized()
        {
            // Act
            var response = await _client.GetAsync("/api/v1/Product");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task Swagger_ShouldBeAvailable()
        {
            // Act
            var response = await _client.GetAsync("/swagger/index.html");

            // Assert
            Assert.True(
                response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Redirect);
        }
    }
}