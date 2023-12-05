namespace DesafioHotmart.Payment.Business
{
    public interface IPaymentFacade
    {
        public Task<bool> PerformPayment(Payment payment);
    }
}
