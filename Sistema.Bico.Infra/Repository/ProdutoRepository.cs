using Microsoft.EntityFrameworkCore;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Interface;
using Sistema.Bico.Infra.Context;
using Sistema.Bico.Infra.Generics.Repository;
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
    }

}
