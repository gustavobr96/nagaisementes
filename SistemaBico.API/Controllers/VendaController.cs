using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sistema.Bico.Domain.Command;
using Sistema.Bico.Domain.Interface;
using SistemaBico.API.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AutoMapper;
using Sistema.Bico.Domain.Command.Venda;

namespace SistemaBico.API.Controllers
{
    [Route("[controller]")]
    public class VendaController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;
        public VendaController(IMediator mediator, 
            IVendaRepository vendaRepository,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _vendaRepository = vendaRepository;
        }

        [HttpPost("registrar")]
        public async Task<bool> RegistrarVenda([FromBody] VendaDto vendaDto)
        {
            var venda = _mapper.Map<RegistrarVendaCommand>(vendaDto);

            try
            {
                var model = await _mediator.Send(venda);
                if (model.IsSuccess){ return true; }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
