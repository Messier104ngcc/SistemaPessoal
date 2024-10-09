using SistemaPessoal.Date;
using SistemaPessoal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SistemaPessoal.Controllers
{
    [Authorize] //protegendo as paginas internas, onde só será acessivel por usuarios altenticados.

    public class DespesasController : Controller
    {
        readonly private ApplicationDbContext _db;
        // buscanco o registro do banco

        public DespesasController(ApplicationDbContext db) 
        { 
            _db = db;
        }
        public IActionResult Index()
        {         
            try
            {
                var viewModel = new ViewModel
                {
                    Saldo = _db.Contas_Bancarias.Sum(t => t.Saldo_Inicial), // Calcula a soma total
                    Despesas = _db.DespesasModel.ToList()
                };
                return View(viewModel);
            }
            catch (Exception)
            {
                ViewBag.MensagemErro = "❌ Tempo limite excedido com o servidor, contate o suporte.";
                return View("Index");
            }
        }

        // metodo que abre a tela de cadastro de despesas, junto com o formulario.
        [HttpGet]
        public IActionResult Cadastrar() 
        {
            return View();
        }

        [HttpPost] // tornando o metodo em post, assim será possivel que todas as informacçoes digitadas sejam salvas no banco de dados.
        public IActionResult Cadastrar(DespesasModel despesas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.DespesasModel.Add(despesas); // adicionado todas as informações no banco.
                    _db.SaveChanges(); // salvando as informações no banco.

                    TempData["MensagemSucesso"] = "Despesas cadastrada!"; // mensagem mostranado ao usuario que o cadastro deu certo.

                    return RedirectToAction("Index"); // apos der tudo certo, retonara para tela Aluno/Index.
                }

                TempData["MensagemErro"] = "Ocorreu algum erro ao Cadastrar a despesa!";
                return View(); // caso der alguma erro, ou o ususario não preencheu as informações certas, permanecerá na tela ate que estja tudo ok.
            }
            catch (Exception)
            {
                ViewBag.MensagemErro = "❌ Erro inesperado. Contate o suporte.";
                return View("CadastroIndex");
            }
        }


        // metdo que vem com o Id selecionado do banco de dados.
        [HttpGet]
        public IActionResult Editar(int? Id) 
        {
            if (Id == null || Id == 0) 
            {
                return NotFound();
            }

            DespesasModel despesa = _db.DespesasModel.FirstOrDefault(x => x.Id == Id); // basicamento é um comando WHERE da tabela na coluna ID.

            if (despesa == null) 
            {
                return NotFound();
            }

            return View(despesa);
        }
        
        // metdo que vem com o Id selecionado do banco de dados.
        [HttpGet]
        public IActionResult Excluir(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            DespesasModel despesa = _db.DespesasModel.FirstOrDefault(x => x.Id == Id); // basicamento é um comando WHERE da tabela na coluna ID.

            if (despesa == null)
            {
                return NotFound();
            }

            return View(despesa);
        }



        // metodo que está recebendo todas as informações preenchidas do banco.
        [HttpPost]
        public IActionResult Editar(DespesasModel despesa)
        {
            if (ModelState.IsValid) 
            {
                _db.DespesasModel.Update(despesa); // atualizando as informações do banco
                _db.SaveChanges(); // salvando as informações atualizadas

                TempData["MensagemSucesso"] = "Alterações realizado com sucesso!"; // mensagem mostranado ao usuario que o cadastro deu certo.

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Ocorreu algum erro de edição das informações!"; // mensagem de erro caso ocorra agum erro apois salvar as alterações.

            return RedirectToAction("Index");
        }
        

        // metodo para excluir registro do banco
        [HttpPost]
        public IActionResult Excluir(DespesasModel despesa)
        {
            if (despesa == null) // condição para verificar se há informações salvas no banco
            {
                ViewBag.MensagemErro = "⚠ Despesa não encontrada ou você não tem permissão para excluí-la.";
                return NoContent();
            }

            _db.DespesasModel.Remove(despesa); 
            _db.SaveChanges();

            TempData["MensagemSucesso"] = " Registro excluido com sucesso!"; // mensagem mostranado ao usuario que o cadastro deu certo.

            return RedirectToAction("Index");   
        }

        public IActionResult Paga(int id)
        {
            var despesa = _db.DespesasModel.Find(id);


            if (despesa != null)
            {
                // Define o valor de 'Paga' como "SIM" antes de atualizar no banco
                despesa.Paga = "Sim";

                _db.SaveChanges(); // salvando as informações atualizadas

                TempData["MensagemSucesso"] = "Pagamento realizado com sucesso!"; // mensagem mostranado ao usuario que o pagamento deu certo.

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Ocorreu algum erro com o Pagamento!"; // mensagem de erro caso ocorra agum erro apois salvar as alterações.

            return View(despesa);
        }
    }

}

