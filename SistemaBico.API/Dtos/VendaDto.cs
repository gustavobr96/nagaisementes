using System;

namespace SistemaBico.API.Dtos
{
    public class VendaDto
    {
        public string ProdutoId { get; set; }
        public string QuantidadeVendida { get; set; }
        public string ValorVendaUnitario { get; set; }
    }
}
