using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
            try
            {
                var viewModel = new ViewModel
                {
                    Despesas = _db.DespesasModel.ToList()
                };
                return View(viewModel);
            }
            catch (SqlException)
            {
                return StatusCode(500, "Ocorreu um erro ao processar sua solicitação. Tente novamente mais tarde.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro inesperado. Contate o suporte.");
            }
        }
    }
}
