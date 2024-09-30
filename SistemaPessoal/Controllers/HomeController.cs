using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaPessoal.Date;
using SistemaPessoal.Models;
using System.Security.Claims;

namespace SistemaPessoal.Controllers
{
    [Authorize] //protegendo as paginas internas, onde só será acessivel por usuarios altenticados.
    public class HomeController : Controller
    {
        readonly private ApplicationDbContext _db;
        // buscanco o registro do banco
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Filtra as despesas pelo ID do usuário
            IEnumerable<DespesasModel> despesa = _db.DespesasModel.Where(t => t.UserId == UserId);

            return View("Index");
        }
    }
}
