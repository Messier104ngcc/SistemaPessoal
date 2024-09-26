using SistemaPessoal.Date.Repositorio.Interfacer;


namespace SistemaPessoal.Date.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepositorio(ApplicationDbContext db)
        {
            _db = db;
        }

        // comando para buscar os dados do banco.
        public List<Models.Usuarios> BuscarUsuario()
        {
            return _db.Login.ToList();
        }

        //responsavel por inserir os dados no banco
        public void CadastrarUsuario(Models.Usuarios usuarios)
        {
            _db.Login.Add(usuarios); //inseri os dados no banco.
            _db.SaveChanges(); //salva os dados no bando.
        }
    }
}
