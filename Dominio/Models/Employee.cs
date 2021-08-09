using Domain.Enum;
using Dominio.Models.Base;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }

#nullable enable
        public ICollection<Image> Images { get; private set; }
#nullable disable

        public DateTime DataRegistro { get; private set; }
        public OfficeEmployee OfficeEmployee { get; private set; }

        public ICollection<Movie> Movies { get; private set; }

        protected Employee() { }

        public Employee(string name, ICollection<Image> images, DateTime birthDate, OfficeEmployee officeEmployee)
        {
            Id = Guid.NewGuid();
            Name = name;
            Images = images;
            BirthDate = birthDate;
            DataRegistro = DateTime.Now;
            OfficeEmployee = officeEmployee;
        }
    }
}
