using SistemaPessoal.Enum;
using System.ComponentModel.DataAnnotations;


namespace SistemaPessoal.Models
{
    public class Usuarios
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "⚠")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "⚠")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "⚠")]
        public string Email { get; set; }

        //public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "⚠")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "⚠")]
        public string ConfSenha { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime? DataAtualizacao {  get; set; } = DateTime.Now;
    }
}
