using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Command.Menu;
using Sistema.Bico.Domain.Command.Produto;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using Sistema.Bico.Infra.Repository;
using SistemaBico.API.Dtos;
using SistemaBico.API.Dtos.ResponseRazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBico.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class MenusController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public MenusController(IMediator mediator, IMenuRepository menuRepository, IMapper mapper)
        {
            _mediator = mediator;
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        [Route("listar")]
        public async Task<IActionResult> ExibirMenus()
        {
            var menus = await ObterMenus();
            var menuDto = _mapper.Map<List<MenuDto>>(menus);

            return View("ExibirMenus", new ListResponseRazor { Menus = menuDto });
        }

        [HttpGet]
        [Route("editar-menu/{id}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            try
            {
                // Recupere os dados do produto pelo ID
                var menu = await _menuRepository.GetEntityById(id);

                if (menu == null)
                {
                    return RedirectToAction("Index", "Erro", new { area = "" }); // Ou outra ação apropriada
                }

                // Mapeie o produto para um objeto ProdutoDto (se necessário)
                var menuDto = _mapper.Map<MenuDto>(menu);

                return View("EditarMenu", menuDto);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Erro", new { area = "" }); // Ou outra ação apropriada
            }
        }


        [Route("registrar")]
        public async Task<IActionResult> Registrar(MenuDto menuDto)
        {
            var menu = _mapper.Map<AddMenuCommand>(menuDto);

            try
            {
                var model = await _mediator.Send(menu);
                if (model.IsSuccess)
                {
                    var menus = await ObterMenus();
                    var menusDto = _mapper.Map<List<MenuDto>>(menus);
                    return RedirectToAction("ExibirMenus", new { menusDto });
                }

                return RedirectToAction("Index", "Erro", new { area = "" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }


        [Route("atualizar")]
        public async Task<IActionResult> Atualizar(MenuDto menuDto)
        {
            try
            {
                var menu = _mapper.Map<EditarMenuCommand>(menuDto);
                var model = await _mediator.Send(menu);

                if (model.IsSuccess)
                {
                    var menus = await ObterMenus();
                    var menusDto = _mapper.Map<List<MenuDto>>(menus);
                    return RedirectToAction("ExibirMenus", new { menusDto });
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
                var desativarAtivarCommand = new AtivarEDesativarMenuCommand { MenuId = Guid.Parse(id) };
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


        [HttpGet("ObterMenus")]
        public async Task<List<Menu>> ObterMenus()
        {
            return await _menuRepository.GetAll();
        }

        [Route("novo-menu")]
        public IActionResult Index()
        {
            return View("NovoMenu");
        }
    }
}
