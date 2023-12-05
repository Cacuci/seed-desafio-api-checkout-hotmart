using DesafioHotmart.Payment.AntiCurruption;
using DesafioHotmart.Payment.Business;

namespace DesafioHotmart.Payment.AntiCorruption
{
    public sealed class PaymentFacade(IPaymentGateway paymentGateway) : IPaymentFacade
    {
        private readonly IPaymentGateway _paymentGateway = paymentGateway;

        public async Task<bool> PerformPayment(Business.Payment payment)
        {
            return await _paymentGateway.CommitTransaction(payment);
        }
    }
}
