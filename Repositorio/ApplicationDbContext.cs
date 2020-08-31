using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebVendas.Dominio.Entidades;

namespace Repositorio.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<VendaProdutos> VendaProdutos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // Não sobrescreve o que já existe no DbContext.OnModelCreating

            builder.Entity<VendaProdutos>()
                .HasKey(x => new { x.CodigoVenda, x.CodigoProduto }); // Define a chave primária dupla

            builder.Entity<VendaProdutos>() // VendaProdutos tem uma venda com muitos produtos
                .HasOne(x => x.Venda)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.CodigoVenda);

            builder.Entity<VendaProdutos>() // VendaProdutos tem um produto com muitas vendas
                .HasOne(x => x.Produto)
                .WithMany(x => x.Vendas)
                .HasForeignKey(x => x.CodigoProduto);

        }

        #region Configurar log para SQL do entity
        //public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory = new LoggerFactory(new[] {
        //    new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        //});

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        //    optionsBuilder.EnableSensitiveDataLogging(true);
        //}
        #endregion
    }
}
