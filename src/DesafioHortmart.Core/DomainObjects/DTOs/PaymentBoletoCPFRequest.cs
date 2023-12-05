using System.ComponentModel.DataAnnotations;

namespace DesafioHortmart.Core.DomainObjects.DTOs
{
    public class PaymentBoletoCPFRequest
    {
        [Required(ErrorMessage = "Campo obrigatório não fornecido")]
        public string CPF { get; set; }
    }
}
