using GoodHamburgerAdmin.Domain;

namespace GoodHamburgerAdmin.Infrastructure;

public interface IClienteRepository
{
    Task<Cliente?> GetByIdAsync(int id);
    Task<List<Cliente>> GetAllAsync();
    Task AddAsync(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(Cliente cliente);
    Task SaveChangesAsync();
}