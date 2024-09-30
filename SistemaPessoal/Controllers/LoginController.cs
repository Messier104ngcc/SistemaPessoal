using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPessoal.Date;
using SistemaPessoal.Date.Repositorio.Interfacer;
using SistemaPessoal.Models;
using System.Security.Claims;
using System.Text;

namespace SistemaPessoal.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Exibir a página de login
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }
              
        // Processa o login do usuário
        [HttpPost]
        public async Task<IActionResult> Entrar(string username, string senha)
        {
            // Verificar se o usuário existe no banco de dados
            var usuarioExistente = _db.Login
                .Where(t => t.UserName == username && t.Senha == senha)
                .FirstOrDefault();

            if (ModelState.IsValid)
            {
                if (usuarioExistente != null)
                {
                    // Criar as claims de identidade do usuário
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Usuario")  // Defina um papel (role) conforme necessário
            };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Criar o cookie de autenticação
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true, // O cookie permanece após o fechamento do navegador
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                    // Redirecionar para a página inicial do sistema após login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Exibe a mensagem de erro se o login for inválido
                    ViewBag.MensagemErro = "❌ Usuário ou senha inválidos!";
                    return View("Index");
                }
            }

            // Se houver erros, reexibir o formulário
            ViewBag.MensagemErro = "❌ Digite um Usuario e Senha.";
            return View("Index");

        }

        // Logout do usuário
        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }


        public IActionResult Cadastrar()
        {
            return View("CadastroIndex");
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarUsuario(Models.Usuarios model)
        {
            if (ModelState.IsValid)
            {
                if (_db.Login.Any(t => model.Senha != model.ConfSenha))
                {
                    ViewBag.MensagemErro = "❌ Senhas não coincidem!";
                    return View("CadastroIndex");
                }

                // Verificar se o usuário já existe
                if (_db.Login.Any(t => t.UserName == model.UserName))
                {
                    ViewBag.Mensagem = " ⚠ Nome de usuário já existente.";
                    return View("CadastroIndex");
                }
                else
                {
                    _db.Login.Add(model);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index", "Login"); // Redirecionar para a página inicial ou outra página
                }
            }

            // Se houver erros, reexibir o formulário
            ViewBag.MensagemErro = "❌ Faltam campos a serem preenchidos.";
            return View("CadastroIndex");
        }
    }
}
