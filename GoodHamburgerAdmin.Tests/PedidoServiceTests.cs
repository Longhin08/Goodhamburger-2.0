using Moq;
using GoodHamburgerAdmin.Domain;
using GoodHamburgerAdmin.Infrastructure;
using GoodHamburgerAdmin.Infrastructure.Services;
using Xunit;

namespace GoodHamburgerAdmin.Tests;

public class PedidoServiceTests
{
    [Fact]
    public async Task CriarPedidoAsync_ComTresOuMaisItens_AplicaDesconto()
    {
        // Arrange
        var repositoryMock = new Mock<IPedidoRepository>();
        var service = new PedidoService(repositoryMock.Object);

        var pedido = new Pedido
        {
            ClienteId = 1,
            Itens = new List<PedidoItem>
            {
                new PedidoItem { ItemId = 1, Quantidade = 3 }
            }
        };

        // Act
        var resultado = await service.CriarPedidoAsync(pedido);

        // Assert
        Assert.Contains("desconto", resultado.Status);
        repositoryMock.Verify(r => r.AddAsync(pedido), Times.Once);
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task CriarPedidoAsync_ComMenosDeTresItens_NaoAplicaDesconto()
    {
        // Arrange
        var repositoryMock = new Mock<IPedidoRepository>();
        var service = new PedidoService(repositoryMock.Object);

        var pedido = new Pedido
        {
            ClienteId = 1,
            Itens = new List<PedidoItem>
            {
                new PedidoItem { ItemId = 1, Quantidade = 1 }
            }
        };

        // Act
        var resultado = await service.CriarPedidoAsync(pedido);

        // Assert
        Assert.DoesNotContain("desconto", resultado.Status);
    }
}