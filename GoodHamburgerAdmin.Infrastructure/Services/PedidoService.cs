using GoodHamburgerAdmin.Domain;

namespace GoodHamburgerAdmin.Infrastructure.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;

    public PedidoService(IPedidoRepository pedidoRepository)
    {
        _pedidoRepository = pedidoRepository;
    }

    public async Task<Pedido?> ObterPorIdAsync(int id) =>
        await _pedidoRepository.GetByIdAsync(id);

    public async Task<List<Pedido>> ObterTodosAsync() =>
        await _pedidoRepository.GetAllAsync();

    public async Task<Pedido> CriarPedidoAsync(Pedido pedido)
    {
        AplicarDesconto(pedido);

        await _pedidoRepository.AddAsync(pedido);
        await _pedidoRepository.SaveChangesAsync();

        return pedido;
    }

    private void AplicarDesconto(Pedido pedido)
    {
        // Regra simples: pedidos com 3 ou mais itens ganham 10% de desconto
        var quantidadeTotal = pedido.Itens.Sum(i => i.Quantidade);

        if (quantidadeTotal >= 3)
        {
            pedido.Status = "Pendente (10% desconto aplicado)";
            // aqui você pode evoluir depois pra ter um campo "ValorTotal" e "Desconto" de verdade
        }
    }
}