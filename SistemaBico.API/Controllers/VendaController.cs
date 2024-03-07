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
using SistemaBico.API.Dtos.ResponseRazor;
using Sistema.Bico.Domain.Entities;
using System.Linq;
using Sistema.Bico.Domain.Generics.Helpers;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace SistemaBico.API.Controllers
{
    [Authorize]
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

        [Route("listar")]
        public async Task<IActionResult> ExibirVendas(DateTime? dataInicial, DateTime? dataFinal)
        {
            var vendas = await FiltrarVendas(dataInicial, dataFinal);

            // Mapear para a DTO
            var vendasDto = _mapper.Map<List<VendaDto>>(vendas);


            decimal lucroTotal = vendas.Sum(Helper.CalcularLucroTotal);
            decimal valorVendaTotal = vendas.Sum(Helper.CalcularValorVendaTotal);

            ViewBag.LucroTotal = lucroTotal.ToString("#,0.000", CultureInfo.InvariantCulture);
            ViewBag.ValorVendaTotal = valorVendaTotal.ToString("#,0.000", CultureInfo.InvariantCulture);

            return View("ExibirVendas", new ListResponseRazor { Vendas = vendasDto });
        }

        private async Task<List<Venda>> FiltrarVendas(DateTime? dataInicial, DateTime? dataFinal)
        {

            dataInicial = dataInicial == null ? DateTime.Now.AddDays(-1) : dataInicial;
            dataFinal = dataFinal == null ? DateTime.Now.AddMonths(1) : dataFinal;

            var vendas = await _vendaRepository.ObterVendasComProdutoPorPeriodo(dataInicial, dataFinal);

            ViewBag.DataInicio = dataInicial?.ToString("yyyy-MM-dd");
            ViewBag.DataFim = dataFinal?.ToString("yyyy-MM-dd");

            return vendas;
        }


    }
}
