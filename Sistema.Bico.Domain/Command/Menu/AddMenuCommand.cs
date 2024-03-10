using Ardalis.Result;
using MediatR;

namespace Sistema.Bico.Domain.Command.Menu
{
    public class AddMenuCommand : IRequest<Result>
    {
        public string Nome { get; set; }
   
    }
}
