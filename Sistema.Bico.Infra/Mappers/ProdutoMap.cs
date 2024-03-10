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

            builder.Property(x => x.Quantidade).HasColumnType("decimal(18, 3)").HasColumnName("Quantidade");
            builder.Property(x => x.Pureza).HasColumnType("decimal(18, 2)").HasColumnName("Pureza");
            builder.Property(x => x.ValorUnitarioCompra).HasColumnType("decimal(18, 2)").HasColumnName("ValorUnitarioCompra");

            builder.HasOne(x => x.Fornecedor).WithMany().HasForeignKey(x => x.FornecedorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Menu).WithMany().HasForeignKey(x => x.MenuId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
