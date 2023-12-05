namespace DesafioHotmart.Payment.Business
{
    public sealed record PaymentCreditCard(string Number, string Name, byte Installment, string Expiration, string Cvv)
    {
        public string Number { get; private set; } = Number;
        public string Name { get; private set; } = Name;
        public byte Installment { get; private set; } = Installment;
        public string Expiration { get; private set; } = Expiration;
        public string Cvv { get; private set; } = Cvv;
    }
}
