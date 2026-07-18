using CRNProduct.Application.Interfaces;
using CRNProduct.Application.Services;
using CRNProduct.Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace CRNProduct.Application.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _productRepositoryMock = new Mock<IProductRepository>();

            _unitOfWorkMock
                .Setup(x => x.Products)
                .Returns(_productRepositoryMock.Object);

            _productService = new ProductService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    ProductName = "Laptop"
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Mouse"
                }
            };

            _productRepositoryMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(products);

            // Act
            var result = await _productService.GetAllAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(products);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                ProductName = "Laptop"
            };

            _productRepositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(product);

            // Act
            var result = await _productService.GetByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result!.ProductName.Should().Be("Laptop");
        }

        [Fact]
        public async Task CreateAsync_ShouldAddProduct_AndSaveChanges()
        {
            // Arrange
            var product = new Product
            {
                ProductName = "Keyboard"
            };

            // Act
            var result = await _productService.CreateAsync(product);

            // Assert
            _productRepositoryMock.Verify(x => x.AddAsync(product), Times.Once);

            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);

            result.Should().Be(product);

            result.CreatedOn.Should().NotBe(default);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateProduct_AndSaveChanges()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                ProductName = "Monitor"
            };

            // Act
            await _productService.UpdateAsync(product);

            // Assert
            _productRepositoryMock.Verify(x => x.Update(product), Times.Once);

            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);

            product.ModifiedOn.Should().NotBeNull();
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteProduct_WhenProductExists()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                ProductName = "Laptop"
            };

            _productRepositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(product);

            // Act
            await _productService.DeleteAsync(1);

            // Assert
            _productRepositoryMock.Verify(x => x.Delete(product), Times.Once);

            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowException_WhenProductNotFound()
        {
            // Arrange
            _productRepositoryMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Product?)null);

            // Act
            Func<Task> act = async () =>
                await _productService.DeleteAsync(1);

            // Assert
            await act.Should()
                     .ThrowAsync<Exception>()
                     .WithMessage("Product not found.");
        }
    }
}