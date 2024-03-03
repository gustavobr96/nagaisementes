using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Bico.Domain.Entities;

namespace Sistema.Bico.Infra.Mappers
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        private const string NOME_TABELA = "Fornecedor";

        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable(NOME_TABELA);

            builder.HasKey(x => new { x.Id }).HasName($"PK_{NOME_TABELA}");
        }
    }
}
