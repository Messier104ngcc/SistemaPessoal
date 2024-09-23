

using SistemaPessoal.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaPessoal.Date
{
    // classe ou instacia responsavel para fazer conecxão com a string do banco.
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  // contrutor
        {
                
        }

        // criando a tabela no banco de dados
        public DbSet<DespesasModel> Despesas { get; set; }

        public DbSet<DespesasModel> Login { get; set; }

    }
}
