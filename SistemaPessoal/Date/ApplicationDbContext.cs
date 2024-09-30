

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Usuarios());
        }

        // criando a tabela no banco de dados
        public DbSet<DespesasModel> DespesasModel { get; set; }

        public DbSet<Models.Usuarios> Login { get; set; }

        public DbSet<Models.Contas_Bancarias> Contas_Bancarias { get; set; }

    }
}
