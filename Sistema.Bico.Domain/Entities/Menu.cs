using System;

namespace Sistema.Bico.Domain.Entities
{
    public class Menu : Base
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;

        public void Atualizar(string nome)
        {
            Nome = nome;
            Update = DateTime.Now;
        }

        public void AtivarDesativar()
        {
            Ativo = Ativo ? false : true;
        }
    }
}
