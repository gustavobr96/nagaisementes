using Ardalis.Result;
using MediatR;

namespace Sistema.Bico.Domain.Command
{
    public class AddFornecedorCommand : IRequest<Result>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CpfCnpj { get; set; }

    }
}
