using Microsoft.EntityFrameworkCore;
using PedidosAPI.Domain.Entities.Parceiro;
using PedidosAPI.Domain.Entities.Pedido;
using PedidosAPI.Domain.Entities.Produto;

namespace PedidosAPI.Infrastructure.Repositories
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Parceiro> Parceiros { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ProdutoPedido> ProdutosPedidos { get; set; }

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
        }

        public ConnectionContext() => this.Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("pedidosApi");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                        .HasKey(p => p.Id);

            modelBuilder.Entity<Parceiro>()
                .OwnsOne(p => p.Nome, nome =>
                {
                    nome.Property(t => t.Valor)
                            .HasColumnName("Nome")
                            .IsRequired();
                });

            modelBuilder.Entity<Parceiro>()
                .OwnsOne(p => p.Email, email =>
                {
                    email.Property(e => e.Endereco)
                         .HasColumnName("Email")
                         .IsRequired();
                });

            modelBuilder.Entity<Parceiro>()
                .OwnsOne(p => p.Telefone, telefone =>
                {
                    telefone.Property(t => t.Numero)
                            .HasColumnName("Telefone")
                            .IsRequired();
                });

            //modelBuilder.Entity<Pedido>()
            //    .OwnsOne(p => p.TipoPedido, tipo =>
            //    {
            //        tipo.Property(t => t.Valor)
            //            .HasColumnName("TipoPedido")
            //            .IsRequired();
            //    });

            //modelBuilder.Entity<Pedido>()
            //    .OwnsOne(p => p.Status, status =>
            //    {
            //        status.Property(s => s.Valor)
            //            .HasColumnName("Status")
            //            .IsRequired();
            //    });

            base.OnModelCreating(modelBuilder);
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=pedidosAPI;" +
                "User Id=postgres;" +
                "Password=2006;");*/
    }
}
