using CadastroDeAlunos2._0.Date;
using CadastroDeAlunos2._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeAlunos2._0.Controllers
{
    public class AlunoController : Controller
    {
        readonly private ApplicationDbContext _db;
        // buscanco o registro do banco
        public AlunoController(ApplicationDbContext db) 
        { 
            _db = db;
        }
        public IActionResult Index()
        {
            // comando para pegar todos os registros do banco ou SELECT * FROM
            IEnumerable<AulasModel> aulas = _db.Aluno;

            return View(aulas);
        }
    }
}
