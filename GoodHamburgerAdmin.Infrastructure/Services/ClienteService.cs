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
    public async Task<bool> AtualizarClienteAsync(int id, Cliente clienteAtualizado)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);

        if (cliente is null)
            return false;

        cliente.Nome = clienteAtualizado.Nome;
        cliente.Email = clienteAtualizado.Email;

        _clienteRepository.Update(cliente);
        await _clienteRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeletarClienteAsync(int id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);

        if (cliente is null)
            return false;

        _clienteRepository.Delete(cliente);
        await _clienteRepository.SaveChangesAsync();

        return true;
    }

}