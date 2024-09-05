
// referencia a uma coluna no banco de dados.
namespace CadastroDeAlunos2._0.Models
{
    public class AulasModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Materia { get; set; }
        public int Sala { get; set; }
        public DateTime DataAula { get; set; }  = DateTime.Now; // siginifica que vai ser atualizado conform a data e horario atual do registro.
    }
}
