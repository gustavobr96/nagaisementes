using Ardalis.Result;
using AutoMapper;
using MediatR;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.UseCases.Produtos
{
    public class AtivarDesativarProdutoCommandHandler : IRequestHandler<AtivarEDesativarProdutoCommand, Result>
    {
        private readonly IProdutoRepository _produtoRepository;

        public AtivarDesativarProdutoCommandHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Result> Handle(AtivarEDesativarProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var produto = await _produtoRepository.GetEntityById(request.ProdutoId);
                produto.AtivarDesativar();

                await _produtoRepository.Update(produto);
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Error("Erro durante a operação.");
            }
        }
    }
}
