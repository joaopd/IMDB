using Domain.Enum;
using System;
using System.Collections.Generic;

namespace Api.DTO
{
    public class RegisterEmployeeDto
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<RegisterImageDto> Images { get; set; }
        public OfficeEmployee OfficeEmployee { get; set; }
    }
}
