using Ardalis.Result;
using MediatR;
using System;

namespace Sistema.Bico.Domain.Command.Menu
{
    public class AtivarEDesativarMenuCommand : IRequest<Result>
    {
        public Guid MenuId { get; set; }
    }
}
