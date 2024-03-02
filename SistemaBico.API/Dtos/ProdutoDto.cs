using Microsoft.AspNetCore.Http;
using Sistema.Bico.Domain.Enums;

namespace SistemaBico.API.Dtos
{
    public class ProdutoDto
    {
        public string DataCadastro { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string FotoBase64 { get; set; }
        public string TipoProduto { get; set; }
        public TipoProduto Tipo { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Pureza { get; set; }
        public int Tetrazolio { get; set; }
        public IFormFile File { get; set; }
    }
}
