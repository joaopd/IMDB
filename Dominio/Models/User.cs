using Dominio.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public bool Admistrator { get; private set; }
        public DateTime DataRegistro { get; private set; }

#nullable enable
        [ForeignKey("Image")]
        public Guid IdImagem { get; set; }
        public Image Image { get; private set; }
#nullable disable

        protected User() { }

        public User(string name, string email, Image image, bool administrator)
        {
            Id = Guid.NewGuid();
            Name = name;
            Image = image;
            Email = new Email(email);
            DataRegistro = DateTime.Now;
            Admistrator = administrator;
        }

        public void TrocarEmail(string email)
        {
            Email = new Email(email);
        }
        public void AdicionarImagem(string image)
        {
            Image = new Image(image);
        }

        public void AddAdmin()
        {
            Admistrator = true;
        }
    }
}
