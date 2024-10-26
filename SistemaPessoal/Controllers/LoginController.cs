using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

            try
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
            catch (Exception)
            {
                ViewBag.MensagemErro = "❌ Erro inesperado. Contate o suporte.";
                return View("CadastroIndex");
            }
        }

        // Logout do usuário
        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }


    }
}
