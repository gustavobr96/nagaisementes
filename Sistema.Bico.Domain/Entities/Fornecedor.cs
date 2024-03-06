using Sistema.Bico.Domain.Enums;
using System;

namespace Sistema.Bico.Domain.Entities
{
    public class Fornecedor : Base
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CpfCnpj { get; set; } = string.Empty;

        public void Atualizar(string nome, string telefone, string cpfCnpj)
        {
            Nome = nome;
            Telefone = telefone;
            CpfCnpj = cpfCnpj;
            Update = DateTime.Now;
        }
    }
}
