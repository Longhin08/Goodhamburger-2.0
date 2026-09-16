using GoodHamburgerAdmin.Domain;

namespace GoodHamburgerAdmin.Infrastructure.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente?> ObterPorIdAsync(int id) =>
        await _clienteRepository.GetByIdAsync(id);

    public async Task<List<Cliente>> ObterTodosAsync() =>
        await _clienteRepository.GetAllAsync();

    public async Task<Cliente> CriarClienteAsync(Cliente cliente)
    {
        await _clienteRepository.AddAsync(cliente);
        await _clienteRepository.SaveChangesAsync();
        return cliente;
    }
}