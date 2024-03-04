using Ardalis.Result;
using MediatR;

namespace Sistema.Bico.Domain.Command.Fornecedor
{
    public class AddFornecedorCommand : IRequest<Result>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CpfCnpj { get; set; }

    }
}
