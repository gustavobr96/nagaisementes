using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema.Bico.Domain.Entities;

namespace Sistema.Bico.Infra.Mappers
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        private const string NOME_TABELA = "Menu";

        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable(NOME_TABELA);

            builder.HasKey(x => new { x.Id }).HasName($"PK_{NOME_TABELA}");

        }
    }
}
