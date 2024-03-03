using Ardalis.Result;
using AutoMapper;
using MediatR;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.UseCases.Fornecedores
{

    public class RegistrarFornecedorHandler : IRequestHandler<AddFornecedorCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IFornecedorRepository _fornecedorRepository;

        public RegistrarFornecedorHandler(IMapper mapper,
            IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AddFornecedorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var produto = _mapper.Map<Fornecedor>(request);
                await _fornecedorRepository.Add(produto);
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Error("Erro durante a operação.");
            }
        }
    }
}
