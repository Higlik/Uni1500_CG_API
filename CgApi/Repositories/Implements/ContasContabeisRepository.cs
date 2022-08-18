using Microsoft.EntityFrameworkCore;

namespace CgApi.Repositories.Implements
{
    public class ContasContabeisRepository : IContasContabeis
    {

        private readonly cursodev_grupo2Context _Grupo2Context;

        public ContasContabeisRepository(cursodev_grupo2Context grupo2Context)
        {
            _Grupo2Context = grupo2Context;
        }

        public Task<TbContasContabeis> CalculateSaldo(decimal saldo, decimal despesa)
        {
            throw new NotImplementedException();
        }

        public async Task CreateConta(CreateNewContaContabeis conta)
        {
            await _Grupo2Context.TbContasContabeis.AddAsync(new TbContasContabeis
            {
                Id = conta.Id,
                Lucro = conta.Lucro,
                Despesas = conta.Despesas,
                Saldo = conta.Saldo
            });
            await _Grupo2Context.SaveChangesAsync();
        }

        public Task<TbContasContabeis> DeleteConta(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TbContasContabeis>> FluxoCaixa(DateTime dataCaixa, decimal saldo, int id)
        {
            return await _Grupo2Context.TbContasContabeis.Where(
                c => c.DataCaixa == dataCaixa && c.Saldo == saldo && c.Id == id).ToListAsync();
        }

        public async Task<List<TbContasContabeis>> GetAllContas()
        {
            return await _Grupo2Context.TbContasContabeis.ToListAsync();
        }

        public Task<TbContasContabeis> UpdateConta(TbContasContabeis conta)
        {
            throw new NotImplementedException();
        }

        Task<TbContasContabeis> IContasContabeis.FluxoCaixa(DateTime dataCaixa, decimal saldo, int id)
        {
            throw new NotImplementedException();
        }
    }
}
