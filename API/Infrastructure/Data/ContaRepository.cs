using Core.Entities;
using Core.Entities.DTOs;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ContaRepository : IContaRepository
    {
        private readonly StoreContext _context;

        public ContaRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Conta> Add(Conta conta)
        {
            await _context.Contas.AddAsync(conta);
            await _context.SaveChangesAsync();

            return conta;
        }

        public async Task<IEnumerable<Conta>> GetAll()
            => await _context.Contas.ToListAsync();

        public async Task<Conta> GetlancamentoById(int id) 
            => await _context.Contas.FindAsync(id);

        public async Task<IReadOnlyList<Conta>> GetLancamentos() 
            => await _context.Contas.ToListAsync();

        public async Task<IReadOnlyList<Conta>> GetLancamentosFiltered(int days)
        {   
            return await _context.Contas.Where(a => a.Data >= DateTime.Now.AddDays(-days) && a.Data <= DateTime.Now).ToListAsync();
        }

        public async Task<bool> ContaExiste(int id)
            => await _context.Contas.AnyAsync(a => a.Id == id);

        public async void AtualizaStatusCancelado(Conta conta)
        {
             conta.AtualizarStatus(StatusEnum.Cancelado);
             await _context.SaveChangesAsync();
        }

        public async Task Update(ContaToEditDto conta)
        {
            var dbConta = await _context.Contas.FindAsync(conta.Id);
            if (dbConta == null)
                throw new Exception("Lancamento not found.");

            dbConta.Valor = conta.Valor;
            dbConta.Data = conta.Data;

            await _context.SaveChangesAsync();

        }

    }
}