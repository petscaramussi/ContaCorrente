using System;
using Core.Entities;

namespace api.DTOs
{
    public class ContaUserDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public Status Status { get; set; }
    }
}
