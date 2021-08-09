using Domain.Models;
using System;
using System.Collections.Generic;

namespace Api.DTO
{
    public class GetMoviesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<GetImageDto> Images { get; set; }
        public string UrlMovie { get; set; }
        public string UrlTrailer { get; set; }
        public ICollection<Employee> Casts { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Excluido { get; set; }
    }
}
