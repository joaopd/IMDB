using Dominio.Models.Base;
using System;

namespace Api.DTO
{
    public class GetUserDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public Email Email { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
