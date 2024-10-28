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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var usuarioId = User.Identity.Name;

            try
            {
                var viewModel = new ViewModel
                {
                    Despesas = _db.DespesasModel.ToList()

                    // // Filtrando apenas as despesas do usuário logado
                    //    Despesas = _db.DespesasModel
                    //      .Where(d => d.UsuariosId == usuarioId)
                    //      .ToList(),

                    //// Filtrando apenas as contas bancárias do usuário logado
                    //    Contas = _db.Contas_Bancarias
                    //             .Where(c => c.UsuariosId == usuarioId)
                    //             .ToList()

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
