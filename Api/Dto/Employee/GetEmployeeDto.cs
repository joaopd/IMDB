using Domain.Enum;
using System;
using System.Collections.Generic;

namespace Api.DTO
{
    public class GetEmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<GetImageDto> Images { get; set; }
        public OfficeEmployee OfficeEmployee { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool Excluido { get; set; }
    }
}
