using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema.Bico.Domain.Command;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System;
using Sistema.Bico.Domain.Interface;
using Sistema.Bico.Infra.Repository;
using Sistema.Bico.Domain.Entities;
using System.Collections.Generic;

namespace SistemaBico.API.Controllers
{
	[Route("api/vendaApi")]
	[ApiController]
	public class VendaAPIController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IVendaRepository _vendaRepository;

		public VendaAPIController(IMediator mediator,
			IVendaRepository vendaRepository)
		{
			_vendaRepository = vendaRepository;
			_mediator = mediator;
		}

		[HttpPost("GetVenda")]
		[SwaggerOperation(Tags = new[] { "VendaApi" })]
		public async Task<List<Venda>> GetProduto()
		{
			var venda = await _vendaRepository.GetAll();

			return venda;
		}

		[HttpPost("Register")]
		[SwaggerOperation(Tags = new[] { "VendaApi" })]
		public async Task<IActionResult> Post(RegistrarVendaCommand addProduto)
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
