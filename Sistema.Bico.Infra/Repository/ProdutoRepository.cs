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
            var listaProdutos = await _context.Produto
                 .Include(i => i.Fornecedor)
                 .Include(i => i.Menu)
                 .AsNoTracking()
                 .ToListAsync();

            if (!string.IsNullOrEmpty(pesquisar)) listaProdutos.Where(x => x.Nome.Contains(pesquisar));

            if (menuID != null) listaProdutos.Where(x => x.MenuId == menuID);

            var count = listaProdutos.Count();

            listaProdutos
             .Skip((page - 1) * take)
             .Take(take);

            return (count, listaProdutos);
        }
    }

}
