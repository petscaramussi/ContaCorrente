namespace Core.Entities
{
    public class Conta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public Avulso Avulso { get; set; }
        public Status Status { get; set; }

    }

    public enum Avulso
    {
        NãoAvulso,
        Avulso
    }

    public enum Status
    {
        Válido,
        Cancelado
    }
}