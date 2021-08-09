using System;

namespace Api.DTO
{
    public class GetImageDto
    {
        public Guid Id { get; set; }
        public string UrlImage { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Excluido { get; set; }
    }
}
