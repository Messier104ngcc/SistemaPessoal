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
            IEnumerable<AulasModel> aluno = _db.Aluno;

            return View(aluno);
        }

        // metodo que abre a tela de cadastro de aulas, iunto com o formulario.
        [HttpGet]
        public IActionResult Cadastrar() 
        {
            return View();
        }

        [HttpPost] // tornando o metodo em post, assim será possivel que todas as informacçoes digitadas sejam salvas no banco de dados.
        public IActionResult Cadastrar(AulasModel aluno)
        {
            if (ModelState.IsValid)
            {
                _db.Aluno.Add(aluno); // adicionado todas as informações no banco.
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

            AulasModel aulas = _db.Aluno.FirstOrDefault(x => x.Id == id); // basicamento é um comando WHERE da tabela na coluna ID.

            if (aulas == null) 
            {
                return NotFound();
            }

            return View(aulas);
        }
        
        // metdo que vem com o Id selecionado do banco de dados.
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            AulasModel aulas = _db.Aluno.FirstOrDefault(x => x.Id == id); // basicamento é um comando WHERE da tabela na coluna ID.

            if (aulas == null)
            {
                return NotFound();
            }

            return View(aulas);
        }



        // metodo que está recebendo todas as informações preenchidas do banco.
        [HttpPost]
        public IActionResult Editar(AulasModel aula)
        {
            if (ModelState.IsValid) 
            {
                _db.Aluno.Update(aula); // atualizando as informações do banco
                _db.SaveChanges(); // salvando as informações atualizadas

                TempData["MensagemSucesso"] = "Alterações realizado com sucesso!"; // mensagem mostranado ao usuario que o cadastro deu certo.

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Ocorreu algum erro de edicção das informações!"; // mensagem de erro caso ocorra agum erro apois salvar as alterações.

            return View(aula);
        }
        

        // metodo para excluir registro do banco
        [HttpPost]
        public IActionResult Excluir(AulasModel aula)
        {
            if (aula == null) // condição para verificar se há infoemações salvas no banco
            {
                return NoContent();
            }

            _db.Aluno.Remove(aula); 
            _db.SaveChanges();

            TempData["MensagemSucesso"] = " Registro excluido com sucesso!"; // mensagem mostranado ao usuario que o cadastro deu certo.

            return RedirectToAction("Index");   
        }

    }
}
