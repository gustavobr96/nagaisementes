using Ardalis.Result;
using AutoMapper;
using MediatR;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Command.Produto;
using Sistema.Bico.Domain.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.UseCases.Fornecedores
{
    public class EditarFornecedorCommandHandler : IRequestHandler<EditarFornecedorCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IFornecedorRepository _fornecedorRepository;

        public EditarFornecedorCommandHandler(IMapper mapper,
            IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(EditarFornecedorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingFornecedor = await _fornecedorRepository.GetEntityById(request.Id);

                if (existingFornecedor == null)
                {
                    return Result.Error("Fornecedor não encontrado.");
                }


                existingFornecedor.Atualizar(request.Nome, request.Telefone, request.CpfCnpj);

                await _fornecedorRepository.Update(existingFornecedor);

                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Error("Erro durante a operação.");
            }
        }
    }
}
