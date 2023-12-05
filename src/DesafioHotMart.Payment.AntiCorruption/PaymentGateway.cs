using DesafioHotmart.Payment.AntiCurruption;

namespace DesafioHotmart.Payment.AntiCorruption
{
    public sealed class PaymentGateway : IPaymentGateway
    {
        public Task<bool> CommitTransaction(Business.Payment payment)
        {
            return Task.FromResult(new Random().Next(1) == 0);
        }
    }
}
