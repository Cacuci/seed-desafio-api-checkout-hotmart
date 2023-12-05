namespace DesafioHotmart.Payment.Business
{
    public interface IPaymentRepository
    {
        public Task Add(Payment payment);
    }
}
