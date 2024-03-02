using Sistema.Bico.Domain.Enums;

namespace Sistema.Bico.Domain.Entities
{
	public class Produto : Base
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public string FotoBase64 { get; set; }
		public TipoProduto TipoProduto { get; set; }
        public decimal Quantidade { get; set; }
        public int Pureza { get; set; }
		public int Tetrazolio { get; set; }

		public void RealizarVenda(decimal quantidadeVendida)
		{
		    Quantidade =  Quantidade - quantidadeVendida;
		}
	}
}
