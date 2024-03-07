using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Generics.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.Interface
{
    public interface IVendaRepository : IGeneric<Venda>
    {
        Task<List<Venda>> ObterVendasComProdutoPorPeriodo(DateTime? dataInicial, DateTime? dataFinal);
    }
}
