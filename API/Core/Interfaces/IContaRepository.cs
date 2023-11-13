using Core.Entities;

namespace Core.Interfaces
{
    public interface IContaRepository
    {
        Task<Conta> GetlancamentoById(int id);
        Task<IReadOnlyList<Conta>> GetLancamentos();
        Task<IReadOnlyList<Conta>> GetLancamentosFiltered(int days);
    }
}