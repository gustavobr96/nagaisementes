using MediatR;

namespace Sistema.Bico.Domain.Command
{
    public class AddClientCommand : AuthenticationCommandBase, IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
