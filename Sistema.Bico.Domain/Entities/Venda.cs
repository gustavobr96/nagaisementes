using Newtonsoft.Json;
using System;

namespace Sistema.Bico.Domain.Entities
{
    public class Venda : Base
    {
        public Produto Produto { get; set; }
        public string ProdutoJson { get; set; }
        public Guid ProdutoId { get; set; }
        public decimal QuantidadeVendida { get; set; }
        public decimal ValorVendaUnitario { get; set; }
        public decimal ValorCompraUnitario { get; set; }


        public void SerializarProdutoJson(Produto produto)
        {
            var fotoBase = produto.FotoBase64;

            produto.FotoBase64 = null;
            ProdutoJson =  JsonConvert.SerializeObject(produto);

            produto.FotoBase64 = fotoBase;
        }
    }
}
