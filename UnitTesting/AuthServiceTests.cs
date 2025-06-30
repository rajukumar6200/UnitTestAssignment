using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOrderSystem.Services;

namespace UnitTesting
{
    public class AuthServiceTests
    {
        [Fact]
        public void IsValidPassword_WithStrongPassword_ReturnsTrue()
        {
            // Arrange
            var authService = new AuthService();
            var password = "StrongPass1!";

            // Act
            var result = authService.IsValidPassword(password);

            // Assert
            Assert.True(result);
            System.Console.WriteLine("✅ Strong password validation passed.");
        }

        [Fact]
        public void IsValidPassword_WithWeakPassword_ReturnsFalse()
        {
            // Arrange
            var authService = new AuthService();
            var password = "Weak"; // too short, no uppercase, no digit, etc.

            // Act
            var result = authService.IsValidPassword(password);

            // Assert
            Assert.False(result);
            System.Console.WriteLine("✅ Weak password correctly rejected.");
        }


        [Fact]
        public async Task IsEmailRegisteredAsync_WithValidEmail_ReturnsTrue()
        {
            // Arrange
            var authService = new AuthService();
            var email = "test@example.com";

            // Act
            var result = await authService.IsEmailRegisteredAsync(email);

            // Assert
            Assert.True(result);
            System.Console.WriteLine("✅ Valid email check passed.");
        }


        [Fact]
        public async Task IsEmailRegisteredAsync_WithInvalidEmail_ReturnsFalse()
        {
            // Arrange
            var authService = new AuthService();
            var email = "invalidemail.com";

            // Act
            var result = await authService.IsEmailRegisteredAsync(email);

            // Assert
            Assert.False(result);
            System.Console.WriteLine("✅ Invalid email check passed.");
        }



    }
}
