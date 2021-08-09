using System;

namespace Dominio.Models.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Excluido { get; private set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            Excluido = false;
        }
        public void Excluir()
        {
            Excluido = true;
        }
    }
}
