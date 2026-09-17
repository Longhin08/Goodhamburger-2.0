using Microsoft.EntityFrameworkCore;
using GoodHamburgerAdmin.Domain;

namespace GoodHamburgerAdmin.Infrastructure;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente?> GetByIdAsync(int id) =>
        await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<List<Cliente>> GetAllAsync() =>
        await _context.Clientes.ToListAsync();

    public async Task AddAsync(Cliente cliente) =>
        await _context.Clientes.AddAsync(cliente);

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
    public void Update(Cliente cliente) =>
    _context.Clientes.Update(cliente);

    public void Delete(Cliente cliente) =>
        _context.Clientes.Remove(cliente);
}