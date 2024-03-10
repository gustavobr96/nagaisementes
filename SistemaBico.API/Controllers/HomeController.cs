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
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
            IProdutoRepository produtoRepository,
            IMapper mapper,
            IMenuRepository menuRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _menuRepository = menuRepository;
        }


        public IActionResult Login()
        {
            return RedirectToAction("index", "Login", new { area = "" });
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await ObterProdutos();
            var menus = await ObterMenus();

            var produtosDto = _mapper.Map<List<ProdutoDto>>(produtos);
            var menusDto = _mapper.Map<List<MenuDto>>(menus);

            return View("index", new ListResponseRazor { Produtos = produtosDto, Menus = menusDto });
        }

        private async Task<List<Produto>> ObterProdutos()
        {
            return await _produtoRepository.GetAll(x => x.Ativo);
        }
        private async Task<List<Menu>> ObterMenus()
        {
            return await _menuRepository.GetAll(x => x.Ativo);
        }

    }
}
