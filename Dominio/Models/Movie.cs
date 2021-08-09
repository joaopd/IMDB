using Dominio.Models.Base;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Movie : BaseEntity
    {
        public string Name { get; private set; }

#nullable enable
        public ICollection<Image> Images { get; private set; }
        public string UrlTrailer { get; private set; }
#nullable disable

        public ICollection<Employee> Casts { get; private set; }
        public DateTime DataRegistro { get; private set; }

        protected Movie() { }

        public Movie(string name, ICollection<Image> images, string urlTrailer, ICollection<Employee> casts)
        {
            Id = Guid.NewGuid();
            Name = name;
            Images = images;
            UrlTrailer = urlTrailer;
            Casts = casts;
            DataRegistro = DateTime.Now;
        }
    }
}
