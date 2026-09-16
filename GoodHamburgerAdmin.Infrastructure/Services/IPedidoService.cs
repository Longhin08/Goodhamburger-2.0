using GoodHamburgerAdmin.Domain;

namespace GoodHamburgerAdmin.Infrastructure.Services;

public interface IPedidoService
{
    Task<Pedido?> ObterPorIdAsync(int id);
    Task<List<Pedido>> ObterTodosAsync();
    Task<Pedido> CriarPedidoAsync(Pedido pedido);
}