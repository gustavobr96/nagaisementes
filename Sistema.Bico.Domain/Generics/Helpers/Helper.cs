using Sistema.Bico.Domain.Entities;
using System;

namespace Sistema.Bico.Domain.Generics.Helpers
{
    public static class Helper
    {
        public static decimal CalcularLucroTotal(Venda venda)
        {
            var lucro  =  venda.QuantidadeVendida * (venda.ValorVendaUnitario - venda.ValorCompraUnitario);
            return lucro;
        }

        public static decimal CalcularValorVendaTotal(Venda venda)
        {
            var lucro = venda.QuantidadeVendida * venda.ValorVendaUnitario;
            return lucro;
        }
    }

}
