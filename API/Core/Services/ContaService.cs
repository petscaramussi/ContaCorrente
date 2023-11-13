using System;
using Core.Entities;
using Core.Entities.DTOs;
using Core.Interfaces.Repository;
using Core.Interfaces.Service;

namespace Core.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<Conta> CreateLancamentoByUser(ContaUserDto dto)
        {
            var contaDto = new Conta(dto: dto);
            return await _contaRepository.Add(contaDto);
        }

        public async Task<Conta> CreateLancamentoByApi(ContaApiDto dto)
        {
            var contaDto = new Conta(dto: dto);
            return await _contaRepository.Add(contaDto);
        }

        public async Task<IEnumerable<Conta>> GetAll()
            => await _contaRepository.GetAll();

        public async Task<bool> ContaExiste(int id)
            => await _contaRepository.ContaExiste(id);

        public async Task<IReadOnlyList<Conta>> GetLancamentos()
            => await _contaRepository.GetLancamentos();

        public async Task<IReadOnlyList<Conta>> GetLancamentosFiltered(int days)
        {
            if (days <= 0)
                throw new Exception("Invalid value");

            return await _contaRepository.GetLancamentosFiltered(days);
        }

        public async Task<Conta> GetlancamentoById(int id)
            => await _contaRepository.GetlancamentoById(id);

        public async Task<Conta> CancelLancamento(int id)
        {
            var dbConta = await _contaRepository.GetlancamentoById(id);

            if (dbConta.Avulso == AvulsoEnum.NaoAvulso)
                throw new Exception("Edit is not Allowed.");

            _contaRepository.AtualizaStatusCancelado(dbConta);

            return await _contaRepository.GetlancamentoById(id);


        }

        public async Task<Conta> AtualizaLancamento(ContaToEditDto dto)
        {
            await _contaRepository.Update(dto);

            return await _contaRepository.GetlancamentoById(dto.Id);

        }
    }
}
