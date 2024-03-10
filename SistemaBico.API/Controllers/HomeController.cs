using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using SistemaBico.API.Dtos;
using SistemaBico.API.Dtos.ResponseRazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBico.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
            IProdutoRepository produtoRepository,
            IMapper mapper)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }


        public IActionResult Login()
        {
            return RedirectToAction("index", "Login", new { area = "" });
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await ObterProdutos();
            var produtosDto = _mapper.Map<List<ProdutoDto>>(produtos);

            return View("index", new ListResponseRazor { Produtos = produtosDto });
        }

        private async Task<List<Produto>> ObterProdutos()
        {
            return await _produtoRepository.GetAll(x => x.Ativo);
        }
    }
}
