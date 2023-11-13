using Core.Entities.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces.Service;
using Core.Interfaces.Repository;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;
        private readonly IContaRepository _repo;
        public ContaController(IContaService contaService, IContaRepository contaRepo)
        {
            _contaService = contaService;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Conta>>> GetLancamentos()
        {
            var lancamentos = await _contaService.GetLancamentos();
            return Ok(lancamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetLancamentoById(int id)
        {
            var lancamento =  await _contaService.GetlancamentoById(id);
            return Ok(lancamento);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLancamentoByUser(ContaUserDto contadto)
        {
            await _contaService.CreateLancamentoByUser(contadto);
            var contas = _contaService.GetAll();
            return Ok(contas);
        }

        [HttpPost]
        [Route("api/Conta/nAvulso")]
        public async Task<IActionResult> CreateLancamentoByAPI(ContaApiDto contadto)
        {
            await _contaService.CreateLancamentoByApi(contadto);
            var contas = _contaService.GetAll();
            return Ok(contas);
        }

        [HttpPut("Cancel/{id}")]
        public async Task<ActionResult<List<Conta>>> CancelLancamento(int id)
        {
            var contas = await _contaService.CancelLancamento(id);
            return Ok(contas);
        }

        // REFATORAR
        [HttpPut]
        public async Task<ActionResult<List<Conta>>> UpdateContaLancamento(ContaToEditDto conta)
        {   

            var lancamento = await _contaService.AtualizaLancamento(conta);
            return Ok(lancamento);
        }

        [HttpGet("Filter/{days}")]
        public async Task<IActionResult> GetLancamentosFiltered(int days)
        {
            var lancamentos = await _contaService.GetLancamentosFiltered(days);
            return Ok(lancamentos);
        }

        [HttpGet("Existe/{id}")]
        public async Task<IActionResult> ContaExiste(int id) 
            => Ok(await _contaService.ContaExiste(id));
    }
}