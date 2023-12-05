namespace DesafioHotmart.Payment.Business
{
    public sealed record PaymentBoleto(ETypeDocument TypeDocument)
    {
        public ETypeDocument TypeDocument { get; private set; } = TypeDocument;
    }
}
