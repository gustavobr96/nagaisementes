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
        public DbSet<Fornecedor> Fornecedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientMap());
            builder.ApplyConfiguration(new ApplicationUserMap());
            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new VendaMap());
            builder.ApplyConfiguration(new FornecedorMap());

            base.OnModelCreating(builder);
        }

        private string GetStringConectionConfig()
        {
            //string strCon = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Agro;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            string strCon = "Data Source=SQL5106.site4now.net;Initial Catalog=db_aa6420_agro;User Id=db_aa6420_agro_admin;Password=@Leteelias5307";

            return strCon;
        }
    }
}
