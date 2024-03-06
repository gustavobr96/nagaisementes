using Ardalis.Result;
using MediatR;
using System;

namespace Sistema.Bico.Domain.Command.Produto
{

    public class EditarFornecedorCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CpfCnpj { get; set; }

    }
}
