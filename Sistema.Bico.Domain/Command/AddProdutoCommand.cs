using Ardalis.Result;
using MediatR;
using Sistema.Bico.Domain.Enums;

namespace Sistema.Bico.Domain.Command
{
    public class AddProdutoCommand : IRequest<Result>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string FotoBase64 { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public int Quantidade { get; set; }
        public int Pureza { get; set; }
        public int Tetrazolio { get; set; }
    }
}
