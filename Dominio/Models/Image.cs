using Dominio.Models.Base;
using System;

namespace Domain.Models
{
    public class Image : BaseEntity
    {
        public string UrlImage { get; private set; }

        public User User { get; private set; }

        public Movie Movie { get; private set; }

        public Employee Employee { get; private set; }

        protected Image() { }

        public Image(string urlImage)
        {
            Id = Guid.NewGuid();
            UrlImage = urlImage;
            DataRegistro = DateTime.Now;
        }
    }
}
