using Microsoft.EntityFrameworkCore;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using Sistema.Bico.Infra.Context;
using Sistema.Bico.Infra.Generics.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Bico.Infra.Repository
{

    public class VendaRepository : RepositoryGenerics<Venda>, IVendaRepository
    {
        private readonly ContextBase _context;

        public VendaRepository(ContextBase context)
        {
            this._context = context;
        }

        public async Task<List<Venda>> ObterVendasComProdutoPorPeriodo(DateTime? dataInicial, DateTime? dataFinal)
        {
            var query = _context.Venda
                .Include(i => i.Produto)
                    .ThenInclude(p => p.Fornecedor)
                .AsQueryable();

            if (dataInicial.HasValue)
            {
                query = query.Where(v => v.Created >= dataInicial);
            }

            if (dataFinal.HasValue)
            {
                query = query.Where(v => v.Created <= dataFinal);
            }

            return await query.OrderBy(x => x.Created).ToListAsync();
        }
    }
}
