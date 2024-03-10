using Sistema.Bico.Domain.Enums;
using System;

namespace Sistema.Bico.Domain.Entities
{
    public class Produto : Base
    {
        public string Nome { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public byte[] FotoBase64 { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Pureza { get; set; }
        public decimal ValorUnitarioCompra { get; set; }
        public int Tetrazolio { get; set; }
        public string Lote { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public Guid FornecedorId { get; set; }
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public void RealizarVenda(decimal quantidadeVendida)
        {
            Quantidade = Quantidade - quantidadeVendida;
        }

        public void Atualizar(string nome, string descricao, string observacao, byte[] fotoBase64, TipoProduto tipoProduto,
         decimal quantidade, decimal pureza, int tetrazolio, Guid fornecedorId,decimal valorUnitarioCompra, Guid menuId, string lote)
        {
            Nome = nome;
            Descricao = descricao;
            Observacao = observacao;
            TipoProduto = tipoProduto;
            Quantidade = quantidade;
            Pureza = pureza;
            Tetrazolio = tetrazolio;
            FornecedorId = fornecedorId;
            Update = DateTime.Now;
            ValorUnitarioCompra = valorUnitarioCompra;
            MenuId = menuId;
            Lote = lote;

            if (fotoBase64 != null && fotoBase64.Length > 0)
                FotoBase64 = fotoBase64;
        }
        public void AtivarDesativar()
        {
            Ativo = Ativo ? false : true;
        }
    }
}
