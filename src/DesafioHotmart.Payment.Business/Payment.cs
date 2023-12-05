using DesafioHortmart.Core.DomainObjects;

namespace DesafioHotmart.Payment.Business
{
    public sealed class Payment : Entity, IAggregateRoot
    {
        public Payment(Guid orderId, ETypePayment typePayment, decimal amount)
        {
            AssertConcern.Null(orderId, "O campo " + nameof(orderId) + " não pode ser nullo");
            AssertConcern.SmallEquallMin(amount, 001, "O campo " + nameof(amount) + " não pode ser menor ou igual a 001");

            OrderId = orderId;
            TypePayment = typePayment;
            Amount = amount;
        }

        private readonly IEnumerable<PaymentCreditCard> _creditCards = new List<PaymentCreditCard>();

        public Guid OrderId { get; private set; }
        public ETypePayment TypePayment { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentBoleto Boleto { get; private set; }
        public IReadOnlyCollection<PaymentCreditCard> CreditCards => _creditCards.ToList();
    }
}
