using Ardalis.Result;
using MediatR;
using System;

namespace Sistema.Bico.Domain.Command
{
    public class AtivarEDesativarProdutoCommand : IRequest<Result>
    {
        public Guid ProdutoId { get; set; }
    }
}
