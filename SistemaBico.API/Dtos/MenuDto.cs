using System;

namespace SistemaBico.API.Dtos
{
    public class MenuDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
