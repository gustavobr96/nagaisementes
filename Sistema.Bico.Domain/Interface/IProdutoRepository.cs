using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Generics.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.Interface
{

    public interface IProdutoRepository : IGeneric<Produto>
    {
        Task<List<Produto>> ObterTodosProdutoEFornecedor();
        Task<(int, List<Produto>)> ObterProdutoPaginado(int page, int take, string pesquisar = null, Guid? menuId = null);
    }
}
