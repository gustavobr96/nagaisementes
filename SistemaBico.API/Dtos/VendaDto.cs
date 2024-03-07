using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaBico.API.Dtos
{
    public class VendaDto
    {
        public string DataVenda { get; set; }
        public string ProdutoId { get; set; }
        public ProdutoDto Produto { get; set; }
        public decimal QuantidadeVendida { get; set; }
        public string ValorVendaUnitario { get; set; }
        public string ValorCompraUnitario { get; set; }
        public string ValorTotalVenda { get; set; }
        public string LucroTotal { get; set; }
    }
}
