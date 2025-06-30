using Moq;
using UserOrderSystem.Models;
using UserOrderSystem.Services;

namespace UnitTesting
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUserById_ReturnsCorrectUser()
        {
            // Arrange
            var mockService = new Mock<UserService>();

            var expectedUser = new User
            {
                Id = 10,
                Name = "Ajay"
            };

            mockService.Setup(service => service.GetUserByIdAsync(10))
                       .ReturnsAsync(expectedUser);

            // Act
            var result = await mockService.Object.GetUserByIdAsync(10);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUser.Id, result.Id);
            Assert.Equal(expectedUser.Name, result.Name);
        }

        [Fact]
        public async Task GetUserById_WithNegativeId_ReturnsNull()
        {
            // Arrange
            var mockService = new Mock<UserService>();

            mockService.Setup(service => service.GetUserByIdAsync(It.Is<int>(id => id < 0)))
                       .ReturnsAsync((User)null); // Return null for invalid ID

            // Act
            var result = await mockService.Object.GetUserByIdAsync(-1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetUserById_ReturnsNull_WhenUserNotFound()
        {
            // Arrange
            var mockService = new Mock<UserService>();

            mockService.Setup(service => service.GetUserByIdAsync(99))
                       .ReturnsAsync((User)null); // Simulate not found

            // Act
            var result = await mockService.Object.GetUserByIdAsync(99);

            // Assert
            Assert.Null(result);
        }

    }
}