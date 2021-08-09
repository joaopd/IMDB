using System;
using System.ComponentModel.DataAnnotations;

namespace Api.DTO
{
    public class ChangeUserDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
    }
}
