namespace CgApi.Repositories
{
    public class CreateNewContaContabeis
    {
        public int Id { get; set; }
        public decimal? Lucro { get; set; }
        public decimal? Despesas { get; set; }
        public decimal? Saldo { get; set; }

        public CreateNewContaContabeis(int id, decimal? lucro, decimal? despesas, decimal? saldo)
        {
            Id = id;
            Lucro = lucro;
            Despesas = despesas;
            Saldo = saldo;
        }
    }
}