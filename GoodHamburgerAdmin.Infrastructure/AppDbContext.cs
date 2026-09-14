using Microsoft.EntityFrameworkCore;
using GoodHamburgerAdmin.Domain;

namespace GoodHamburgerAdmin.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Item> Itens => Set<Item>();
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<PedidoItem> PedidoItens => Set<PedidoItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PedidoItem>()
            .HasOne(pi => pi.Item)
            .WithMany()
            .HasForeignKey(pi => pi.ItemId);

        modelBuilder.Entity<Pedido>()
            .HasMany(p => p.Itens)
            .WithOne()
            .HasForeignKey(pi => pi.PedidoId);
    }
}