using Ardalis.Result;
using AutoMapper;
using MediatR;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.UseCases.Produtos
{
    public class RegistrarProdutoCommandHandler : IRequestHandler<AddProdutoCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public RegistrarProdutoCommandHandler(IMapper mapper,
            IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AddProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var produto = _mapper.Map<Produto>(request);
                await _produtoRepository.Add(produto);
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Error("Erro durante a operação.");
            }
        }
    }
}
