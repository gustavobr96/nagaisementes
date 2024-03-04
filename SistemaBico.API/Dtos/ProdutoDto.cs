using Microsoft.AspNetCore.Http;
using Sistema.Bico.Domain.Enums;
using System;

namespace SistemaBico.API.Dtos
{
    public class ProdutoDto
    {
        public string ProdutoId { get; set; }
        public string DataCadastro { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string FotoBase64 { get; set; }
        public string TipoProduto { get; set; }
        public TipoProduto Tipo { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Pureza { get; set; }
        public int Tetrazolio { get; set; }
        public string FornecedorId { get; set; }
        public string FornecedorName { get; set; }
        public string Observacao { get; set; }
        public bool Ativo { get; set; }
        public IFormFile File { get; set; }
    }
}
