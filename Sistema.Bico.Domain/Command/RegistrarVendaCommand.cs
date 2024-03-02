using Ardalis.Result;
using MediatR;
using System;

namespace Sistema.Bico.Domain.Command
{
	public class RegistrarVendaCommand : IRequest<Result>
	{
        public Guid ProdutoId { get; set; }
        public int Quandidade { get; set; }
    }
}
