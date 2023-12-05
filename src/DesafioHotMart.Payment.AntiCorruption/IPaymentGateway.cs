namespace DesafioHotmart.Payment.AntiCurruption
{
    public interface IPaymentGateway
    {
        public Task<bool> CommitTransaction(Business.Payment payment);
    }
}
