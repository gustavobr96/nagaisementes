using Ardalis.Result;
using MediatR;
using System;

namespace Sistema.Bico.Domain.Command.Venda
{
    public class RegistrarVendaCommand : IRequest<Result>
    {
        public Guid ProdutoId { get; set; }
        public decimal QuantidadeVendida { get; set; }
        public decimal ValorVendaUnitario { get; set; }
    }
}
