using Microsoft.AspNetCore.Mvc;
using SistemaPessoal.Date;
using SistemaPessoal.Models;

namespace SistemaPessoal.Controllers
{
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
            // comando para pegar todos os registros do banco ou SELECT * FROM
            IEnumerable<DespesasModel> home = _db.Despesas;

            return View(home);
        }
    }
}
