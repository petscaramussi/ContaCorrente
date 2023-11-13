using Core.Entities;
using Core.Entities.DTOs;

namespace Core.Interfaces.Repository
{
    public interface IContaRepository
    {

        Task<Conta> Add(Conta conta);
        Task<IEnumerable<Conta>> GetAll();
        Task<Conta> GetlancamentoById(int id);
        Task<IReadOnlyList<Conta>> GetLancamentos();
        Task<IReadOnlyList<Conta>> GetLancamentosFiltered(int days);
        Task<bool> ContaExiste(int id);
        Task Update(ContaToEditDto conta);
        void AtualizaStatusCancelado(Conta conta);
    }
}