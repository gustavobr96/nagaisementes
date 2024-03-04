using Ardalis.Result;
using MediatR;
using System;

namespace Sistema.Bico.Domain.Command.Venda
{
    public class RegistrarVendaCommand : IRequest<Result>
    {
        public Guid ProdutoId { get; set; }
        public int Quandidade { get; set; }
    }
}
