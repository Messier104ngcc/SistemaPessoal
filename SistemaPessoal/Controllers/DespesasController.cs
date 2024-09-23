using SistemaPessoal.Date;
using SistemaPessoal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemaPessoal.Controllers
{
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
            // comando para pegar todos os registros do banco ou SELECT * FROM
            IEnumerable<DespesasModel> despesas = _db.Despesas;

            return View(despesas);
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
            if (ModelState.IsValid)
            {
                _db.Despesas.Add(despesas); // adicionado todas as informações no banco.
                _db.SaveChanges(); // salvando as informações no banco.

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!"; // mensagem mostranado ao usuario que o cadastro deu certo.

                return RedirectToAction("Index"); // apos der tudo certo, retonara para tela Aluno/Index.
            }

            return View(); // caso der alguma erro, ou o ususario não preencheu as informações certas, permanecerá na tela ate que estja tudo ok.
        }


        // metdo que vem com o Id selecionado do banco de dados.
        [HttpGet]
        public IActionResult Editar(int? id) 
        {
            if (id == null || id ==0) 
            {
                return NotFound();
            }

            DespesasModel despesas = _db.Despesas.FirstOrDefault(x => x.Id == id); // basicamento é um comando WHERE da tabela na coluna ID.

            if (despesas == null) 
            {
                return NotFound();
            }

            return View(despesas);
        }
        
        // metdo que vem com o Id selecionado do banco de dados.
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DespesasModel despesas = _db.Despesas.FirstOrDefault(x => x.Id == id); // basicamento é um comando WHERE da tabela na coluna ID.

            if (despesas == null)
            {
                return NotFound();
            }

            return View(despesas);
        }



        // metodo que está recebendo todas as informações preenchidas do banco.
        [HttpPost]
        public IActionResult Editar(DespesasModel despesas)
        {
            if (ModelState.IsValid) 
            {
                _db.Despesas.Update(despesas); // atualizando as informações do banco
                _db.SaveChanges(); // salvando as informações atualizadas

                TempData["MensagemSucesso"] = "Alterações realizado com sucesso!"; // mensagem mostranado ao usuario que o cadastro deu certo.

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Ocorreu algum erro de edicção das informações!"; // mensagem de erro caso ocorra agum erro apois salvar as alterações.

            return View(despesas);
        }
        

        // metodo para excluir registro do banco
        [HttpPost]
        public IActionResult Excluir(DespesasModel despesas)
        {
            if (despesas == null) // condição para verificar se há infoemações salvas no banco
            {
                return NoContent();
            }

            _db.Despesas.Remove(despesas); 
            _db.SaveChanges();

            TempData["MensagemSucesso"] = " Registro excluido com sucesso!"; // mensagem mostranado ao usuario que o cadastro deu certo.

            return RedirectToAction("Index");   
        }

        public IActionResult Paga(int id)
        {
            var despesa = _db.Despesas.Find(id);


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

