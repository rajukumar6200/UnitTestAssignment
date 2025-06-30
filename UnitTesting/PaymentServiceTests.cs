using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserOrderSystem.Data;
using UserOrderSystem.Models;
using UserOrderSystem.Services;
using Xunit;

namespace UnitTestAssignment.UnitTest
{
    public class PaymentServiceTests
    {
        private readonly PaymentService _paymentService;

        public PaymentServiceTests()
        {
            _paymentService = new PaymentService();
        }

        [Fact]
        public void ProcessPayment_ShouldThrowException_WhenOrderIsNull()
        {
            // Arrange
            Order order = null;

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _paymentService.ProcessPayment(order));
            Assert.Equal("Order cannot be null.", ex.Message);
        }

        [Fact]
        public void ProcessPayment_ShouldThrowException_WhenOrderIsAlreadyPaid()
        {
            // Arrange
            var order = new Order
            {
                Id = 1,
                IsPaid = true
            };

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _paymentService.ProcessPayment(order));
            Assert.Equal("Order already paid.", ex.Message);
        }

        [Fact]
        public void ProcessPayment_ShouldSetIsPaidTrue_WhenOrderIsValid()
        {
            // Arrange
            var order = new Order
            {
                Id = 2,
                IsPaid = false
            };

            // Act
            _paymentService.ProcessPayment(order);

            // Assert
            Assert.True(order.IsPaid);
        }
    }
}
