using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
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

            builder.Property(x => x.QuantidadeVendida) .HasColumnType("decimal(18, 3)").HasColumnName("QuantidadeVendida");
            builder.Property(x => x.ValorVendaUnitario).HasColumnType("decimal(18, 3)").HasColumnName("ValorVendaUnitario");
            builder.Property(x => x.ValorCompraUnitario).HasColumnType("decimal(18, 3)").HasColumnName("ValorCompraUnitario");

            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.ProdutoId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
