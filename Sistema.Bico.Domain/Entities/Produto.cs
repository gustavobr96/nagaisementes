using Sistema.Bico.Domain.Enums;
using System;

namespace Sistema.Bico.Domain.Entities
{
    public class Produto : Base
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public byte[] FotoBase64 { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Pureza { get; set; }
        public int Tetrazolio { get; set; }
        public bool Ativo { get; set; } = true;
        public Guid FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public void RealizarVenda(decimal quantidadeVendida)
        {
            Quantidade = Quantidade - quantidadeVendida;
        }

        public void AtivarDesativar()
        {
            Ativo = Ativo ? false : true;
        }
    }
}
