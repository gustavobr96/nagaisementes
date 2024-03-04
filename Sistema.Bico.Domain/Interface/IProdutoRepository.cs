using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Generics.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.Bico.Domain.Interface
{

    public interface IProdutoRepository : IGeneric<Produto>
    {
        Task<List<Produto>> ObterTodosProdutoEFornecedor();
    }
}
