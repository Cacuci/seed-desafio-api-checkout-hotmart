namespace DesafioHotmart.Payment.Business
{
    public class PaymentService(IPaymentFacade paymentFacade, IPaymentRepository paymentRepository) : IPaymentService
    {
        private readonly IPaymentFacade _paymentFacade = paymentFacade;
        private readonly IPaymentRepository _paymentRepository = paymentRepository;

        public Task AddPaymentOrder()
        {
            _paymentRepository.Add();
        }
    }
}
