using UserOrderSystem.Models;

namespace UnitTestAssignment.Interface
{
    public interface IPaymentService
    {
        void ProcessPayment(Order order);
    }
}
