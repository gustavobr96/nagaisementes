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
    public class EditarProdutoCommandHandler : IRequestHandler<EditarProdutoCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public EditarProdutoCommandHandler(IMapper mapper,
            IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(EditarProdutoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduto = await _produtoRepository.GetEntityById(request.Id);

                if (existingProduto == null)
                {
                    return Result.Error("Produto não encontrado.");
                }


                existingProduto.Atualizar(request.Nome, request.Descricao, request.Observacao,
                    request.FotoBase64, request.TipoProduto, request.Quantidade, request.Pureza, request.Tetrazolio, request.FornecedorId);

                await _produtoRepository.Update(existingProduto);

                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Error("Erro durante a operação.");
            }
        }
    }
}
