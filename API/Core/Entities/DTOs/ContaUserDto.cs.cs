namespace Core.Entities.DTOs
{
    public class ContaUserDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public StatusEnum Status { get; set; }
    }
}
