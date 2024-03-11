using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using SistemaBico.API.Dtos;
using SistemaBico.API.Dtos.Filter;
using SistemaBico.API.Dtos.ResponseRazor;
using System;
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

        //public async Task<IActionResult> Index()
        //{
        //    var filter = new FilterPaginatedHomeDto();

        //    var produtos = await ObterProdutosPaginados(filter.Page, filter.Take);
        //    var menus = await ObterMenus();

        //    var pagesSize = Math.Ceiling((decimal)produtos.Item1 / filter.Take);

        //    var produtosDto = _mapper.Map<List<ProdutoDto>>(produtos.Item2);
        //    var menusDto = _mapper.Map<List<MenuDto>>(menus);

        //    var paginacao = new PaginacaoRazorDto { CountRegister = produtos.Item1, PagesSize = (int)pagesSize };
        //    return View("index", new ListResponseRazor { Produtos = produtosDto, Menus = menusDto, Paginacao = paginacao });
        //}

        //[HttpPost("Pesquisar")]
        //public async Task<IActionResult> Pesquisar(FilterPaginatedHomeDto filter)
        //{
        //    var produtos = await ObterProdutosPaginados(filter.Page, filter.Take, filter.Pesquisar, filter.MenuId);

        //    var pagesSize = Math.Ceiling((decimal)produtos.Item1 / filter.Take);

        //    var menus = await ObterMenus();
        //    var produtosDto = _mapper.Map<List<ProdutoDto>>(produtos.Item2);
        //    var menusDto = _mapper.Map<List<MenuDto>>(menus);

        //    var paginacao = new PaginacaoRazorDto { CountRegister = produtos.Item1, PagesSize = (int)pagesSize, Page = filter.Page, Skip = filter.Skip, Take = filter.Take };
        //    return View("index", new ListResponseRazor { Produtos = produtosDto, Menus = menusDto, Paginacao = paginacao });
        //}
        public async Task<IActionResult> Index(int page = 1)
        {
            var filter = new FilterPaginatedHomeDto();

            var produtos = await ObterProdutosPaginados(page, filter.Take);
            var menus = await ObterMenus();

            var pagesSize = Math.Ceiling((decimal)produtos.Item1 / filter.Take);

            var produtosDto = _mapper.Map<List<ProdutoDto>>(produtos.Item2);
            var menusDto = _mapper.Map<List<MenuDto>>(menus);

            var paginacao = new PaginacaoRazorDto { CountRegister = produtos.Item1, PagesSize = (int)pagesSize, Page = page };
            return View("index", new ListResponseRazor { Produtos = produtosDto, Menus = menusDto, Paginacao = paginacao });
        }

        [HttpPost("Pesquisar")]
        public async Task<IActionResult> Pesquisar(string search, string menuId)
        {
            var filter = new FilterPaginatedHomeDto();

            var produtos = await ObterProdutosPaginados(filter.Page, filter.Take, search, menuId);

            var pagesSize = Math.Ceiling((decimal)produtos.Item1 / filter.Take);

            var menus = await ObterMenus();
            var produtosDto = _mapper.Map<List<ProdutoDto>>(produtos.Item2);
            var menusDto = _mapper.Map<List<MenuDto>>(menus);

            var paginacao = new PaginacaoRazorDto { CountRegister = produtos.Item1, PagesSize = (int)pagesSize, Page = filter.Page, Skip = filter.Skip, Take = filter.Take };
            return View("index", new ListResponseRazor { Produtos = produtosDto, Menus = menusDto, Paginacao = paginacao });
        }
        private async Task<List<Menu>> ObterMenus()
        {
            return await _menuRepository.GetAll(x => x.Ativo);
        }

        private async Task<(int, List<Produto>)> ObterProdutosPaginados(int page, int take, string pesquisar = null, string menuId = null)
        {
            Guid? menuID = null;
           
            if (!string.IsNullOrEmpty(menuId))
                 menuID = Guid.Parse(menuId);
            

            return await _produtoRepository.ObterProdutoPaginado(page, take, pesquisar, menuID);
        } 
    }
}
