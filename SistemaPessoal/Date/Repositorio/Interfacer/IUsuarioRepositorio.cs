using SistemaPessoal.Models;

namespace SistemaPessoal.Repositorio.Interfacer
{
    public interface IUsuarioRepositorio
    {
        List<Usuarios> BuscarUsuario();

        Usuarios BuscarPorID(int id);

        Usuarios CadastrarUsuario(Usuarios usuarios);

        Usuarios Atualizar(Usuarios usuario);

        bool Excluir (int id);

        bool UsuarioExistePorNome(string userName);
        bool UsuarioExistePorEmail(string email);
    }
}
