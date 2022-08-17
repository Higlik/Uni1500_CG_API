using CgApi.Repositories.Implements;

namespace CgApi.Repositories
{
    public interface IContasContabeis
    {
        Task CreateConta(CreateNewContaContabeis conta);
        Task<TbContasContabeis> UpdateConta(TbContasContabeis conta);
        Task<TbContasContabeis> DeleteConta(int id);
        Task<List<TbContasContabeis>> GetAllContas();
        Task<TbContasContabeis> CalculateSaldo(decimal saldo, decimal despesa);

    }
}