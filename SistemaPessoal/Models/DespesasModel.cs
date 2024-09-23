
using System.ComponentModel.DataAnnotations;

// referencia a uma coluna no banco de dados.
namespace SistemaPessoal.Models
{
    public class DespesasModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome da Despesa!")] // mensagem de erro caso o usuario tente adicionar os campos sem valores.
        public string? Despesa { get; set; }

        [Required(ErrorMessage = "Digite uma Observação!")]
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "Digite um Valor!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Digite um Vencimento!")]
        public DateTime Vencimento { get; set; } 

        public string? Paga {  get; set; }
    }
}
