using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using SistemaBico.API.Dtos;
using SistemaBico.API.Dtos.ResponseRazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBico.API.Controllers
{
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public ProdutosController(IMediator mediator,
            IProdutoRepository produtoRepository,
            IMapper mapper,
            IFornecedorRepository fornecedorRepository)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
        }


        [Route("novo-produto")]
        public async Task<IActionResult> Index()
        {
            var fornecedores = await _fornecedorRepository.GetAll();
            var fornecedoresDto = _mapper.Map<List<FornecedorDto>>(fornecedores);

            ViewBag.Fornecedores = fornecedoresDto;
            return View("NovoProduto");
        }

        [Route("listar")]
        public async Task<IActionResult> ExibirProdutos()
        {
            var produtos = await ObterProdutos();
            var produtosDto = _mapper.Map<List<ProdutoDto>>(produtos);

            return View("ExibirProdutos", new ListResponseRazor { Produtos = produtosDto });
        }


        [Route("registrar")]
        public async Task<IActionResult> Registrar(ProdutoDto produtoDto)
        {
            var produto = _mapper.Map<AddProdutoCommand>(produtoDto);

            try
            {
                var model = await _mediator.Send(produto);
                if (model.IsSuccess)
                {
                    var produtos = await ObterProdutos();
                    var produtosDto = _mapper.Map<List<ProdutoDto>>(produtos);
                    return View("ExibirProdutos", new ListResponseRazor { Produtos = produtosDto });
                }

                return RedirectToAction("Index", "Erro", new { area = "" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }

        private async Task<List<Produto>> ObterProdutos()
        {
            return await _produtoRepository.ObterTodosProdutoEFornecedor();
        }
    }
}
