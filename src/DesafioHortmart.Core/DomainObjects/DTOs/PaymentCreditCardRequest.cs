using System.ComponentModel.DataAnnotations;

namespace DesafioHortmart.Core.DomainObjects.DTOs
{
    public class PaymentCreditCardRequest
    {
        [Required(ErrorMessage = "Campo obrigatório não fornecido")]
        [CreditCard(ErrorMessage = "Número do cartão de crédito inválido")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Campo obrigatório não fornecido")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório não fornecido")]
        [Range(minimum: 1, maximum: 12, ErrorMessage = "Valor deve ser entre 1 e 12")]
        public byte Installment { get; set; }

        [Required(ErrorMessage = "Campo obrigatório não fornecido")]
        public string Expiration { get; set; }

        [Required(ErrorMessage = "Campo obrigatório não fornecido")]
        [Length(minimumLength: 1, maximumLength: 3, ErrorMessage = "Precia conter 3 caracteres")]
        public string Cvv { get; set; }
    }
}
