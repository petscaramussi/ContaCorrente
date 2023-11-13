using api.DTOs;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaRepository _repo;
        private readonly StoreContext _context;
        public ContaController(IContaRepository repo, StoreContext context)
        {
            _repo = repo;
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Conta>>> GetLancamentos()
        {
            var lancamentos = await _repo.GetLancamentos();

            return Ok(lancamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetLancamentoById(int id)
        {
            return await _repo.GetlancamentoById(id);
        }

        [HttpPost]
        public async Task<ActionResult<List<Conta>>> CreateLancamentoByUser(ContaUserDto contadto)
        {
            var contaDto = new Conta{
                Descricao = contadto.Descricao,
                Data = DateTime.Now.Date,
                Valor = contadto.Valor,
                Avulso = Avulso.Avulso,
                Status = Status.Válido
            };

            _context.Contas.Add(contaDto);
            await _context.SaveChangesAsync();

            return Ok(await _context.Contas.ToListAsync());
        }

        [HttpPost]
        [Route("api/Conta/nAvulso")]
        public async Task<ActionResult<List<Conta>>> CreateLancamentoByAPI(ContaApiDto contadto)
        {
            var contaDto = new Conta{
                Id = contadto.Id,
                Descricao = contadto.Descricao,
                Data = contadto.Data,
                Valor = contadto.Valor,
                Avulso = Avulso.NãoAvulso,
                Status = Status.Válido
            };
            
            _context.Contas.Add(contaDto);
            await _context.SaveChangesAsync();

            return Ok(await _context.Contas.ToListAsync());
        }

        [HttpPut("Cancel/{id}")]
        public async Task<ActionResult<List<Conta>>> CancelLancamento(int id)
        {
            var dbConta = await _context.Contas.FindAsync(id);
            if ( dbConta.Avulso == Avulso.NãoAvulso) 
            {
                return BadRequest("Edit is not Allowed.");
            }

            dbConta.Status = Status.Cancelado;

            await _context.SaveChangesAsync();

            return Ok(await _context.Contas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Conta>>> UpdateContaLancamento(ContaToEditDto conta)
        {
            
            var dbConta = await _context.Contas.FindAsync(conta.Id);

            if (dbConta == null)
                return BadRequest("Lancamento not found.");

            if (dbConta.Avulso == Avulso.NãoAvulso)
                return BadRequest("Edit is not Allowed.");

            dbConta.Valor = conta.Valor;
            dbConta.Data = conta.Data;

            await _context.SaveChangesAsync();

            return Ok(await _context.Contas.ToListAsync());

        }

        [HttpGet("Filter/{days}")]
        public async Task<ActionResult<List<Conta>>> GetLancamentosFiltered(int days)
        {
            var lancamentos = await _repo.GetLancamentosFiltered(days);

            return Ok(lancamentos);
        }


    }
}