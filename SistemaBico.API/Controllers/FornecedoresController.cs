using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Command.Fornecedor;
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
	public class FornecedoresController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedoresController(IMediator mediator, IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _mediator = mediator;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        [Route("novo-fornecedor")]
        public IActionResult Index()
        {
            return View("NovoFornecedor");
        }

        [Route("listar")]
        public async Task<IActionResult> ExibirFornecedores()
        {
            var fornecedores = await ObterFornecedores();
            var fornecedorDto = _mapper.Map<List<FornecedorDto>>(fornecedores);

            return View("ExibirFornecedores", new ListResponseRazor { Fornecedores = fornecedorDto });
        }

        [HttpGet]
        [Route("editar-fornecedor/{id}")]
        public async Task<IActionResult> Editar(Guid id)
        {
            try
            {
                // Recupere os dados do produto pelo ID
                var fornecedor = await _fornecedorRepository.GetEntityById(id);

                if (fornecedor == null)
                {
                    return RedirectToAction("Index", "Erro", new { area = "" }); // Ou outra ação apropriada
                }

                // Mapeie o produto para um objeto ProdutoDto (se necessário)
                var fornecedorDto = _mapper.Map<FornecedorDto>(fornecedor);

                return View("EditarFornecedor", fornecedorDto);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Erro", new { area = "" }); // Ou outra ação apropriada
            }
        }


        [Route("atualizar")]
        public async Task<IActionResult> Atualizar(FornecedorDto fornecedorDto)
        {
            try
            {
                var fornecedor = _mapper.Map<EditarFornecedorCommand>(fornecedorDto);
                var model = await _mediator.Send(fornecedor);

                if (model.IsSuccess)
                {
                    var fornecedores = await ObterFornecedores();
                    var fornecedoresDto = _mapper.Map<List<FornecedorDto>>(fornecedores);
                    return RedirectToAction("ExibirFornecedores", fornecedoresDto);
                }

                return RedirectToAction("Index", "Erro", new { area = "" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }


        [Route("registrar")]
        public async Task<IActionResult> Registrar(FornecedorDto fornecedorDto)
        {
            var fornecedor = _mapper.Map<AddFornecedorCommand>(fornecedorDto);

            try
            {
                var model = await _mediator.Send(fornecedor);
                if (model.IsSuccess)
                {
                    var fornecedores = await ObterFornecedores();
                    var fornecedoresDto = _mapper.Map<List<FornecedorDto>>(fornecedores);
                    return RedirectToAction("ExibirFornecedores", new { fornecedoresDto });
                }

                return RedirectToAction("Index", "Erro", new { area = "" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Erro", new { area = "" });
            }
        }

        [HttpGet("ObterFornecedores")]
        public async Task<List<Fornecedor>> ObterFornecedores()
        {
            return await _fornecedorRepository.GetAll();
        }

    }
}
