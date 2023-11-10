using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Infrastructure.Data
{
    public class ContaRepository : IContaRepository
    {
        private readonly StoreContext _context;
        public ContaRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Conta> GetlancamentoById(int id)
        {
            return await _context.Contas.FindAsync(id);
        }

        public async Task<IReadOnlyList<Conta>> GetLancamentos()
        {
            return await _context.Contas.ToListAsync();
        }
    }
}