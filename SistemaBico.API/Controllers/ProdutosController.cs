using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using SistemaBico.API.Dtos;
using SistemaBico.API.Dtos.ResponseRazor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBico.API.Controllers
{
    [Authorize]
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
                    return RedirectToAction("ExibirProdutos", produtosDto);
                }

                return RedirectToAction("Index", "Erro", new { area = "" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }

        [HttpGet]
        [Route("editar-produto/{id}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            try
            {
                // Recupere os dados do produto pelo ID
                var produto = await _produtoRepository.GetEntityById(id);

                if (produto == null)
                {
                    return RedirectToAction("Index", "Erro", new { area = "" }); // Ou outra ação apropriada
                }

                // Mapeie o produto para um objeto ProdutoDto (se necessário)
                var produtoDto = _mapper.Map<ProdutoDto>(produto);

                // Obtenha a lista de fornecedores (se necessário)
                var fornecedores = await _fornecedorRepository.GetAll();
                var fornecedoresDto = _mapper.Map<List<FornecedorDto>>(fornecedores);

                ViewBag.Fornecedores = fornecedoresDto;

                return View("EditarProduto", produtoDto);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Erro", new { area = "" }); // Ou outra ação apropriada
            }
        }

        [HttpGet]
        [Route("obter-produto/{id}")]
        public async Task<ProdutoDto> ObterProduto(Guid id)
        {
            try
            {
                // Recupere os dados do produto pelo ID
                var produto = await _produtoRepository.GetEntityById(id);
                var produtoDto = _mapper.Map<ProdutoDto>(produto);

                return produtoDto;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [Route("atualizar")]
        public async Task<IActionResult> Atualizar(ProdutoDto produtoDto)
        {
            try
            {
                // Validar os dados conforme necessário

                var produto = _mapper.Map<EditarProdutoCommand>(produtoDto);
                var model = await _mediator.Send(produto);

                if (model.IsSuccess)
                {
                    var produtos = await ObterProdutos();
                    var produtosDto = _mapper.Map<List<ProdutoDto>>(produtos);
                    return RedirectToAction("ExibirProdutos", produtosDto);
                }

                return RedirectToAction("Index", "Erro", new { area = "" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }
    


        [Route("ativarDesativar")]
        public async Task<IActionResult> AtivarDesativar([FromBody] string id)
        {
            try
            {
                var desativarAtivarCommand = new AtivarEDesativarProdutoCommand { ProdutoId = Guid.Parse(id) };
                var model = await _mediator.Send(desativarAtivarCommand);
                if (model.IsSuccess)
                {

                    return Json(new { success = true });
                }

                return Json(new { success = false });
            }
            catch (Exception e)
            {
                return Json(new { success = false });
            }
        }


        private async Task<List<Produto>> ObterProdutos()
        {
            return await _produtoRepository.ObterTodosProdutoEFornecedor();
        }
    }
}
