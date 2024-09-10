

using System.ComponentModel.DataAnnotations;

// referencia a uma coluna no banco de dados.
namespace CadastroDeAlunos2._0.Models
{
    public class AulasModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Aluno!")] // mensagem de erro caso o usuario tente adicionar os campos sem valores.
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Digite o nome da Materia!")]
        public string? Materia { get; set; }

        [Required(ErrorMessage = "Digite o numero da Sala!")]
        public int? Sala { get; set; }
        public DateTime DataAula { get; set; }  = DateTime.Now; // siginifica que vai ser atualizado conform a data e horario atual do registro.
    }
}
