using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Bico.Domain.Entities;

namespace Sistema.Bico.Infra.Mappers
{

	public class VendaMap : IEntityTypeConfiguration<Venda>
	{
		private const string NOME_TABELA = "Venda";

		public void Configure(EntityTypeBuilder<Venda> builder)
		{
			builder.ToTable(NOME_TABELA);

			builder.HasKey(x => new { x.Id }).HasName($"PK_{NOME_TABELA}");
		}
	}
}
