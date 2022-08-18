namespace CgApi.Models
{
    public class TbFluxoCaixa
    {

        public int Id { get; set; }

        public decimal? Lucro { get; set; }
        public decimal? Despesas { get; set; }
        public DateTime? DataCaixa { get; set; }
        public decimal? Saldo { get; set; }

        public int IdContaContabil { get; set; }
        public virtual TbContasContabeis? ContaContabil { get; set; }

    }
}
