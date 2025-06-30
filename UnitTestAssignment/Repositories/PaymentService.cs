using System;
using UnitTestAssignment.Interface;
using UserOrderSystem.Models;

namespace UserOrderSystem.Services
{

    public class PaymentService : IPaymentService
    {
       
        public void ProcessPayment(Order order)
        {

           
            if (order == null)
                throw new InvalidOperationException("Order cannot be null.");
            if (order.IsPaid)
                throw new InvalidOperationException("Order already paid.");

            order.IsPaid = true;
        }
    }
}