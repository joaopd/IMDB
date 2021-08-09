using System;

namespace Dominio.Models.Base
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
    }
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataRegistro { get; set; }


        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            Excluido = false;
            DataRegistro = DateTime.Now;
        }
        public void Excluir()
        {
            Excluido = true;
        }
    }
}
