using DesafioHortmart.Core.DomainObjects.DTOs;

namespace DesafioHotmart.Payment.Business
{
    public class PaymentService(IPaymentFacade paymentFacade, IPaymentRepository paymentRepository) : IPaymentService
    {
        private readonly IPaymentFacade _paymentFacade = paymentFacade;
        private readonly IPaymentRepository _paymentRepository = paymentRepository;

        public Task AddPaymentOrder(ETypePayment eTypePayment)
        {
            throw new NotImplementedException();
        }

        public Task AddPaymentOrder(PaymentCreditCardRequest payment)
        {
            throw new NotImplementedException();
        }

        public Task AddPaymentOrder(IEnumerable<PaymentCreditCardRequest> payment)
        {
            throw new NotImplementedException();
        }

        public Task AddPaymentOrder(PaymentBoletoCPFRequest payment)
        {
            throw new NotImplementedException();
        }

        public Task AddPaymentOrder(PaymentBoletoCNPJRequest payment)
        {
            throw new NotImplementedException();
        }
    }
}
