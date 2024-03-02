using System;

namespace Sistema.Bico.Domain.Entities
{
	public class Venda : Base
	{
		public Venda Produto { get; set; }
		public Guid ProdutoId { get; set; }
		public decimal QuantidadeVendida { get; set; }
	}
}
