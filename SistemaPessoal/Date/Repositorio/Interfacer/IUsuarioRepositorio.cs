namespace SistemaPessoal.Date.Repositorio.Interfacer
{
    public interface IUsuarioRepositorio
    {
        List<Models.Usuarios> BuscarUsuario();

        void CadastrarUsuario(Models.Usuarios usuarios);
    }
}
