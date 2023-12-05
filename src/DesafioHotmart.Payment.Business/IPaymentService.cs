using DesafioHortmart.Core.DomainObjects.DTOs;

namespace DesafioHotmart.Payment.Business
{
    public interface IPaymentService
    {
        public Task AddPaymentOrder(ETypePayment eTypePayment);
        public Task AddPaymentOrder(PaymentCreditCardRequest payment);
        public Task AddPaymentOrder(IEnumerable<PaymentCreditCardRequest> payment);
        public Task AddPaymentOrder(PaymentBoletoCPFRequest payment);
        public Task AddPaymentOrder(PaymentBoletoCNPJRequest payment);
    }
}
