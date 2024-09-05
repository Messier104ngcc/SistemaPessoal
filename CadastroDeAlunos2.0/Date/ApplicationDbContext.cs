

using CadastroDeAlunos2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeAlunos2._0.Date
{
    // classe ou instacia responsavel para fazer conecxão com a string do banco.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  // contrutor
        {
                
        }

        // criando a tabela no banco de dados
        public DbSet<AulasModel> Aluno { get; set; }
    }
}
