using Microsoft.AspNetCore.Mvc;
using SistemaPessoal.Date;

namespace SistemaPessoal.Controllers
{
    public class ConfigController : Controller
    {

        readonly private ApplicationDbContext _db;
        private List<Models.Usuarios> Usuarios;

        // buscanco o registro do banco
        public ConfigController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult GerenciamentoUsuario()
        {
            Usuarios = _db.Login.ToList();
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View("CadastroUsuariosIndex");
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarUsuario(Models.Usuarios model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_db.Login.Any(t => model.Senha != model.ConfSenha))
                    {
                        TempData["MensagemErro"] = "❌ Senhas não coincidem!";
                        return View("CadastroUsuariosIndex");
                    }

                    if (_db.Login.Any(t => t.Email == model.Email))
                    {
                        TempData["MensagemErro"] = " ⚠ Email já cadastrado, tente outro email.";
                        return View("CadastroUsuariosIndex");
                    }
                    // Verificar se o usuário já existe
                    if (_db.Login.Any(t => t.UserName == model.UserName))
                    {
                        TempData["MensagemErro"] = " ⚠ Nome de usuário já existente.";
                        return View("CadastroUsuariosIndex");
                    }
                    else
                    {
                        _db.Login.Add(model);
                        await _db.SaveChangesAsync();
                        TempData["MensagemSucesso"] = "✔ Usuario Cadastrado com Sucesso.";

                        return RedirectToAction("GerenciamentoUsuario"); // Redirecionar para a página inicial ou outra página
                    }
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
