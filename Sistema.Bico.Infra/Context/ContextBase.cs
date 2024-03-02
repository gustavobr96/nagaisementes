using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema.Bico.Domain.Entities;
using Sistema.Bico.Domain.Generics.Entities;
using Sistema.Bico.Infra.Mappers;

namespace Sistema.Bico.Infra.Context
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        { }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Produto> Produto { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); // Mova esta linha para fora do bloco condicional
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientMap());
            builder.ApplyConfiguration(new ApplicationUserMap());
            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new VendaMap());

            base.OnModelCreating(builder);
        }
    }
}
