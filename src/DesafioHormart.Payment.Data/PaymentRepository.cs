using DesafioHotmart.Payment.Business;

namespace DesafioHormart.Payment.Data
{
    internal sealed class PaymentRepository(PaymentContext paymentContext) : IPaymentRepository
    {
        private readonly PaymentContext _paymentContext = paymentContext;

        public Task Add(DesafioHotmart.Payment.Business.Payment payment)
        {
            _paymentContext.Payments.Add(payment);

            return Task.CompletedTask;
        }
    }
}
