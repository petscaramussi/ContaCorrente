using System;
using Core.Entities;
using Core.Entities.DTOs;

namespace Core.Interfaces.Service
{
    public interface IContaService
    {
        Task<Conta> GetlancamentoById(int id);
        Task<IReadOnlyList<Conta>> GetLancamentos();
        Task<IReadOnlyList<Conta>> GetLancamentosFiltered(int days);
        Task<Conta> CreateLancamentoByUser(ContaUserDto dto);
        Task<Conta> CreateLancamentoByApi(ContaApiDto dto);
        Task<Conta> CancelLancamento(int id);
        Task<IEnumerable<Conta>> GetAll();
        Task<bool> ContaExiste(int id);
        Task<Conta> AtualizaLancamento(ContaToEditDto dto);
    }
}
