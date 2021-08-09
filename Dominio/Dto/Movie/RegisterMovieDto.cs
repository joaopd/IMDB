using System;
using System.Collections.Generic;

namespace Api.DTO
{
    public class RegisterMovieDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<RegisterImageDto> Images { get; set; }
        public string UrlMovie { get; set; }
        public string UrlTrailer { get; set; }
        public ICollection<Guid> Casts { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Excluido { get; set; }
    }
}
