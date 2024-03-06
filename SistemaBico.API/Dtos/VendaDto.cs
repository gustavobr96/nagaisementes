using System;

namespace SistemaBico.API.Dtos
{
    public class VendaDto
    {
        public string ProdutoId { get; set; }
        public decimal QuantidadeVendida { get; set; }
        public decimal ValorVendaUnitario { get; set; }
    }
}
