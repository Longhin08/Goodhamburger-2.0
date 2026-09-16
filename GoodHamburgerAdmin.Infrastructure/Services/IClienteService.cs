using GoodHamburgerAdmin.Domain;

namespace GoodHamburgerAdmin.Infrastructure.Services;

public interface IClienteService
{
    Task<Cliente?> ObterPorIdAsync(int id);
    Task<List<Cliente>> ObterTodosAsync();
    Task<Cliente> CriarClienteAsync(Cliente cliente);
}