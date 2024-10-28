using Microsoft.EntityFrameworkCore;
using SistemaPessoal.Date;
using SistemaPessoal.Models;
using SistemaPessoal.Repositorio.Interfacer;


namespace SistemaPessoal.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepositorio(ApplicationDbContext db)
        {
            this._db = db;
        }

        // comando para buscar pelo Id no dados do banco.
        public Usuarios BuscarPorID(int id) { 

            return _db.Usuarios.FirstOrDefault(t => t.UserId == id);

        }

        // comando para buscar os dados do banco.
        public List<Usuarios> BuscarUsuario()
        {
            return _db.Usuarios.ToList();
        }

        // verificações no cadastro do Usuário
        public bool UsuarioExistePorNome(string userName)
        {
            return _db.Usuarios.Any(t => t.UserName == userName);
        }

        public bool UsuarioExistePorEmail(string email)
        {
            return _db.Usuarios.Any(t => t.Email == email);
        }

        //responsavel por inserir os dados no banco
        public Usuarios CadastrarUsuario(Usuarios usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _db.Usuarios.Add(usuario); //inseri os dados no banco.
            _db.SaveChanges(); //salva os dados no bando.
            return usuario;
        }

        public Usuarios Atualizar(Usuarios usuario) 
        {
            Usuarios usuarioDb =  BuscarPorID(usuario.UserId);

            if (usuarioDb == null) throw new Exception("Houve um erro na Atualização do Usuario!");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.UserName = usuario.UserName;
            //usuarioDb.Perfil = usuario.Perfil;  
            usuarioDb.DataAtualizacao = DateTime.Now;

            _db.Usuarios.Update(usuarioDb);
            _db.SaveChanges();

            return usuarioDb;
        }

        public bool Excluir(int id)
        {
            Usuarios usuarioDb = BuscarPorID(id);

            if (usuarioDb == null) throw new Exception("Houve um erro ao excluir o Usuario!");

            _db.Usuarios.Remove(usuarioDb);
            _db.SaveChanges(); 
            
            return true;
        }

    }
}
