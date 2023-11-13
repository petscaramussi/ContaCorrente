using Core.Entities.DTOs;

namespace Core.Entities
{
    public class Conta
    {
        public int Id { get; set; } = default;
        public string Descricao { get; set; } = string.Empty;
        public DateTime Data { get; set; } = default;
        public decimal Valor { get; set; } = default;
        public AvulsoEnum Avulso { get; set; } = default;
        public StatusEnum Status { get; set; } = default;

        public Conta() { }

        public Conta(ContaUserDto dto)
        {
            Descricao = dto.Descricao;
            Data = DateTime.Now.Date;
            Valor = dto.Valor;
            Avulso = AvulsoEnum.Avulso;
            Status = StatusEnum.Valido;
        }

        public Conta(ContaApiDto dto)
        {
            Id = dto.Id;
            Descricao = dto.Descricao;
            Data = DateTime.Now.Date;
            Valor = dto.Valor;
            Avulso = AvulsoEnum.Avulso;
            Status = StatusEnum.Valido;
        }

        public Conta(ContaToEditDto dto)
        {
            Id = dto.Id;
            Data = dto.Data;
            Valor = dto.Valor;
        }

        public void AtualizarStatus(StatusEnum status) => Status = status;
    }

    public enum AvulsoEnum
    {
        NaoAvulso,
        Avulso
    }

    public enum StatusEnum
    {
        Valido,
        Cancelado
    }
}