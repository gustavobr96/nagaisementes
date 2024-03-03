using System.Collections.Generic;

namespace SistemaBico.API.Dtos.ResponseRazor
{
    public class ListResponseRazor
    {
        public List<ProdutoDto> Produtos { get; set; }
        public List<FornecedorDto> Fornecedores { get; set; }
    }
}
