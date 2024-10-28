namespace SistemaPessoal.Models
{
    public class ViewModel
    {
        public decimal Saldo { get; set; }

        public IEnumerable<DespesasModel> Despesas { get; set; }

        public IEnumerable<Contas_Bancarias> Contas { get; set; }

    }
}
