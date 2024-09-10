//using CadastroDeAlunos2._0.Date;
//using CadastroDeAlunos2._0.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace CadastroDeAlunos2._0.Controllers
//{
//    public class LoginController : Controller
//    {

//        readonly private ApplicationDbContext _db;
//        // buscanco o registro do banco
//        public LoginController(ApplicationDbContext db)
//        {
//            _db = db;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Login(LoginModel login)
//        {
//            // Verificar se o usuário existe no banco de dados
//            var usuario = _db.Login.FirstOrDefault(u => u.Username == username && u.Senha == senha);

//            if (usuario != null)
//            {
//                // Usuário encontrado, redireciona para a área do sistema
//                // Aqui você pode definir uma sessão, se necessário
//                Session["UsuarioLogado"] = usuario;
//                return RedirectToAction("Index", "Home");  // Redireciona para a Home ou outra página do sistema
//            }
//            else
//            {
//                // Usuário não encontrado, exibe mensagem de erro
//                ViewBag.MensagemErro = "Usuário ou senha incorretos. Verifique suas credenciais.";
//                return View();
//            }
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                _context.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//    }
//}
