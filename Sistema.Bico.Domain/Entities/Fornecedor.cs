namespace Sistema.Bico.Domain.Entities
{
    public class Fornecedor : Base
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CpfCnpj { get; set; } = string.Empty;
    }
}
