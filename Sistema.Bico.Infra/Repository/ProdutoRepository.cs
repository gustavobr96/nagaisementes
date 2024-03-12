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
    public class ProdutoRepository : RepositoryGenerics<Produto>, IProdutoRepository
    {
        private readonly ContextBase _context;

        public ProdutoRepository(ContextBase context)
        {
            this._context = context;
        }

        public async Task<List<Produto>> ObterTodosProdutoEFornecedor()
        {
            return await _context.Produto
                  .Include(i => i.Fornecedor)
                  .Include(i => i.Menu).ToListAsync();
        }

        public async Task<(int, List<Produto>)> ObterProdutoPaginado(int page, int take, string pesquisar = null, Guid? menuID = null)
        {
            var query = _context.Produto
            .Include(i => i.Fornecedor)
            .Include(i => i.Menu)
            .Where(w => w.Ativo)
            .AsNoTracking();
    
            if (!string.IsNullOrEmpty(pesquisar))
            {
                query = query.Where(x => x.Nome.Contains(pesquisar));
            }

            if (menuID != null)
            {
                query = query.Where(x => x.MenuId == menuID);
            }

            var count = await query.CountAsync();

            var listaProdutos = await query
                .Skip((page - 1) * take)
                .Take(take)
                .ToListAsync();

            return (count, listaProdutos);
        }
    }

}
