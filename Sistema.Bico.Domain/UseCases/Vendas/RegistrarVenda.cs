using Ardalis.Result;
using AutoMapper;
using MediatR;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.UseCases.Vendas
{
    public class RegistrarVendaCommandHandler : IRequestHandler<RegistrarVendaCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IVendaRepository _vendaRepository;

        public RegistrarVendaCommandHandler(IMapper mapper,
            IProdutoRepository produtoRepository,
            IVendaRepository vendaRepository)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _vendaRepository = vendaRepository;
        }

        public async Task<Result> Handle(RegistrarVendaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var produto = await _produtoRepository.GetEntityById(request.ProdutoId);

                if (produto == null) return Result.Error("Produto não encontrado");

                if (request.Quandidade > produto.Quantidade) return Result.Error("Quantidade maior do que possui no estoque.");


                var venda = _mapper.Map<Venda>(request);
                produto.RealizarVenda(request.Quandidade);

                await _vendaRepository.Add(venda);
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
