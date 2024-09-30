using System.ComponentModel.DataAnnotations;

namespace SistemaPessoal.Models
{
    public class Contas_Bancarias
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "⚠")] // mensagem de erro caso o usuario tente adicionar os campos sem valores.
        public string? Nome_Da_Conta { get; set; }

        [Required(ErrorMessage = "⚠")]
        public decimal Saldo_Inicial { get; set; }
    }
}
