using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Bico.Domain.Entities;

namespace Sistema.Bico.Infra.Mappers
{
	public class ProdutoMap : IEntityTypeConfiguration<Produto>
	{
		private const string NOME_TABELA = "Produto";

		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder.ToTable(NOME_TABELA);

			builder.HasKey(x => new { x.Id }).HasName($"PK_{NOME_TABELA}");
		}
	}
}
