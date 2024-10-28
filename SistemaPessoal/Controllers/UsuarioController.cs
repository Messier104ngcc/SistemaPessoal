using Microsoft.AspNetCore.Mvc;
using SistemaPessoal.Models;
using SistemaPessoal.Repositorio.Interfacer;

namespace SistemaPessoal.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _db;

        // buscanco o registro do banco
        public UsuarioController(IUsuarioRepositorio db)
        {
            _db = db;
        }
        public IActionResult GerenciamentoUsuario()
        {
            List<Usuarios> usuarios = _db.BuscarUsuario();
            return View(usuarios);
        }

        public IActionResult Cadastrar()
        {
            return View("CadastroUsuariosIndex");
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Verificar se o usuário já existe pelo nome de usuário e email usando métodos de verificação
                    if (_db.UsuarioExistePorNome(usuario.UserName))
                    {
                        TempData["MensagemErro"] = "⚠ Nome de usuário já existente.";
                        return View("CadastroUsuariosIndex");
                    }
                    if (_db.UsuarioExistePorEmail(usuario.Email))
                    {
                        TempData["MensagemErro"] = "⚠ Email já cadastrado, tente outro email.";
                        return View("CadastroUsuariosIndex");
                    }
                    if (usuario.Senha != usuario.ConfSenha)
                    {
                        TempData["MensagemErro"] = "❌ Senhas não coincidem!";
                        return View("CadastroUsuariosIndex");
                    }

                    // Chamando o método CadastrarUsuario com o parâmetro correto
                    _db.CadastrarUsuario(usuario);
                    TempData["MensagemSucesso"] = "✔ Usuario Cadastrado com Sucesso.";

                    return RedirectToAction("GerenciamentoUsuario"); // Redireciona para a página de gerenciamento
                }

                // Se houver erros, reexibir o formulário
                TempData["MensagemErro"] = "❌ Faltam campos a serem preenchidos.";
                return View("CadastroUsuariosIndex");
            }
            catch (Exception)
            {
                TempData["MensagemErro"] = "❌ Erro inesperado. Contate o suporte.";
                return View("CadastroUsuariosIndex");
            }
        }

    }
}
