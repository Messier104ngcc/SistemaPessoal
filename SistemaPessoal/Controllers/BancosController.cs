using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaPessoal.Date;
using SistemaPessoal.Models;

namespace SistemaPessoal.Controllers
{
    public class BancosController : Controller
    {
        private ApplicationDbContext _db;

        public BancosController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost] // tornando o metodo em post, assim será possivel que todas as informacçoes digitadas sejam salvas no banco de dados.
        public IActionResult Salvar(Contas_Bancarias contas)
        {
            if (ModelState.IsValid)
            {
                _db.Contas_Bancarias.Add(contas); // adicionado todas as informações no banco.
                _db.SaveChanges(); // salvando as informações no banco.

                ViewBag.MensagemSucesso = "✔ Deposito Realizado.";

                return RedirectToAction("Index"); // apos der tudo certo, retonara para tela Bancos/Index.
            }

            ViewBag.MensagemErro = "❌ Faltam campos a serem preenchidos.";
            return View("Index");
        }

        //[HttpGet]
        //public IActionResult Excluir(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    DespesasModel despesa = _db.DespesasModel.FirstOrDefault(x => x.Id == id); // basicamento é um comando WHERE da tabela na coluna ID.

        //    if (despesa == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(despesa);
        //}
    }
}
