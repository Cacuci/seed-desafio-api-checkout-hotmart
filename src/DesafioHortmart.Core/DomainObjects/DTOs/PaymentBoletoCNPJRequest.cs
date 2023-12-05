using System.ComponentModel.DataAnnotations;

namespace DesafioHortmart.Core.DomainObjects.DTOs
{
    public class PaymentBoletoCNPJRequest
    {
        [Required(ErrorMessage = "Campo obrigatório não fornecido")]
        public string CNPJ { get; set; }
    }
}
