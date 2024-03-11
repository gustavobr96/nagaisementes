using SistemaBico.API.Dtos.Filter;
using System.Collections.Generic;

namespace SistemaBico.API.Dtos.ResponseRazor
{
    public class ListResponseRazor
    {
        public List<ProdutoDto> Produtos { get; set; }
        public List<FornecedorDto> Fornecedores { get; set; }
        public List<VendaDto> Vendas { get; set; }
        public List<MenuDto> Menus { get; set; }
        public PaginacaoRazorDto Paginacao { get; set; }
    }
}
