using Ardalis.Result;
using MediatR;
using System;

namespace Sistema.Bico.Domain.Command.Menu
{
    public class EditarMenuCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
