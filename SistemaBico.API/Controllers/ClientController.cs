using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Generics.Entities;
using Sistema.Bico.Domain.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace SistemaBico.API.Controllers
{
	[Authorize]
    [ApiController]
    [Route("v{version:apiVersion}/api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClientController(IClientRepository clientRepository,
            IMediator mediator,
            UserManager<ApplicationUser> userManager)
        {
            _clientRepository = clientRepository;
            _mediator = mediator;
            _userManager = userManager;

        }

        [AllowAnonymous]
        [HttpPost("Register")]
        [SwaggerOperation(Tags = new[] { "Client" })]
        public async Task<IActionResult> Post(AddClientCommand addClientCommand)
        {
            try
            {
                var model = await _mediator.Send(addClientCommand);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
        }


        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Client" })]
        public async Task<IActionResult> Get()
        {
            var model = await _clientRepository.GetAll();
            return Ok(model);
        }
    }
}
