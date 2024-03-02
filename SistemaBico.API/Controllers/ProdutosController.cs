using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sistema.Bico.Domain.Interface;
using SistemaBico.API.Dtos;
using SistemaBico.API.Dtos.ResponseRazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBico.API.Controllers
{
	[Route("[controller]")]
	public class ProdutosController : Controller
	{
		private readonly IMediator _mediator;
		private readonly IProdutoRepository _produtoRepository;
		private readonly IMapper _mapper;

		public ProdutosController(IMediator mediator,
			IProdutoRepository produtoRepository,
			IMapper mapper)
		{
			_mediator = mediator;
			_produtoRepository = produtoRepository;
			_mapper = mapper;
		}


		[Route("novo-produto")]
		public IActionResult Index()
		{
			return View("NovoProduto");
		}

		[Route("listar")]
		public async Task<IActionResult> ExibirProdutos()
		{
			var produto = await _produtoRepository.GetAll();
			var produtoDto = _mapper.Map<List<ProdutoDto>>(produto);


			return View("ExibirProdutos", new ProdutoResponseRazor { Produtos  = produtoDto });
		}

	}
}
