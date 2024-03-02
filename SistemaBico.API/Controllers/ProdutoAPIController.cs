using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBico.API.Controllers
{
    [Route("api/produtoApi")]
    [ApiController]
    public class ProdutoAPIController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoAPIController(IMediator mediator,
            IProdutoRepository produtoRepository)
        {
            _mediator = mediator;
            _produtoRepository = produtoRepository;
        }

        [HttpPost("GetProduto")]
        [SwaggerOperation(Tags = new[] { "ProdutoApi" })]
        public async Task<List<Produto>> GetProduto()
        {
            var produto = await _produtoRepository.GetAll();

            return produto;
        }

        [HttpPost("Register")]
        [SwaggerOperation(Tags = new[] { "ProdutoApi" })]
        public async Task<IActionResult> Post(AddProdutoCommand addProduto)
        {
            try
            {
                var model = await _mediator.Send(addProduto);
                return Ok(200);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }
    }
}
